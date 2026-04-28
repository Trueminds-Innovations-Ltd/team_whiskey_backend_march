using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Common.Exceptions;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Users.Commands;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Users.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto?> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Normalize and validate email early
            var email = (request.Email ?? string.Empty).Trim().ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required", nameof(request.Email));

            // 1) Check uniqueness at application level
            if (await _userRepository.ExistsByEmailAsync(email, cancellationToken))
            {
                throw new DuplicateEmailException(email);
            }

            var passwordHash = _passwordHasher.Hash(request.Password);

            // Build notification prefs JSON; default to true if not provided
            var emailPref = request.EmailNotifications ?? true;
            var notificationPrefs = JsonSerializer.Serialize(new { email = emailPref });

            var user = new User(
                email,
                request.FullName,
                passwordHash,
                request.Role,
                request.Discipline,
                request.CohortYear,
                request.PhoneNumber
            );

            // Set optional profile fields
            if (!string.IsNullOrWhiteSpace(request.Bio))
            {
                typeof(User).GetProperty("Bio")?.SetValue(user, request.Bio);
            }

            if (!string.IsNullOrWhiteSpace(request.ProfilePhotoUrl))
            {
                typeof(User).GetProperty("ProfilePhotoUrl")?.SetValue(user, request.ProfilePhotoUrl);
            }

            typeof(User).GetProperty("NotificationPrefs")?.SetValue(user, notificationPrefs);

            try
            {
                await _userRepository.AddAsync(user, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                // A DB-level uniqueness violation may still occur due to race conditions.
                // Return null so the controller can respond with a Conflict (409).
                throw new DuplicateEmailException(email);
            }

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                Discipline = user.Discipline,
                CohortYear = user.CohortYear,
                PhoneNumber = user.PhoneNumber,
                Bio = user.Bio,
                ProfilePhotoUrl = user.ProfilePhotoUrl,
                EmailNotifications = emailPref,
                LearnerId = user.LearnerId
            };
        }
    }
}
