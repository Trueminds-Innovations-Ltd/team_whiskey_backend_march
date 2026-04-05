using MediatR;
using TalentFlow.Application.Users.Commands;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Users.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginUserHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByLearnerIdAsync(request.LearnerId, cancellationToken);
            if (user == null || user.Email != request.Email)
                throw new UnauthorizedAccessException("Invalid credentials");

            // Generate JWT token
            return _jwtTokenService.GenerateToken(user.LearnerId, user.Email);
        }
    }
}
