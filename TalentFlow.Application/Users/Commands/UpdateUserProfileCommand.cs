using System;
using MediatR;

namespace TalentFlow.Application.Users.Commands
{
    public class UpdateUserProfileCommand : IRequest<bool>
    {
        public Guid LearnerId { get; set; }   // Guid identifier
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
