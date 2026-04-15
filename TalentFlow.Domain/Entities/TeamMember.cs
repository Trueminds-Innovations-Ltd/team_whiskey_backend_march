using System;
using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    [Table("team_member")]
    public class TeamMember : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid TeamId { get; private set; }
        public Guid UserId { get; private set; }
        public string Role { get; private set; } = "Member"; // Member, Leader, etc.
        public DateTime JoinedAt { get; private set; } = DateTime.UtcNow;

        // Audit fields
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public string? DeletedBy { get; private set; }

        private TeamMember() { } // EF Core

        public TeamMember(Guid teamId, Guid userId, string role = "Member")
        {
            Id = Guid.NewGuid();
            TeamId = teamId;
            UserId = userId;
            Role = role;
            JoinedAt = DateTime.UtcNow;
        }

        public void UpdateRole(string role, string updatedBy)
        {
            Role = role;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SoftDelete(string deletedBy)
        {
            IsDeleted = true;
            DeletedBy = deletedBy;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
