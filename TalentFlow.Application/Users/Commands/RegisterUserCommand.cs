using MediatR;

namespace TalentFlow.Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<UserDto>
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Discipline { get; set; } = string.Empty;
        public int CohortYear { get; set; }

        // Optional profile fields
        public string? Bio { get; set; }
        public string? ProfilePhotoUrl { get; set; }

        // Optional toggle; null means "not provided" — handler can default to true or false
        public bool? EmailNotifications { get; set; }

        // Phone number already present
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
