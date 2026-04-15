using System;
using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    [Table("team_file")]
    public class TeamFile : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid TeamId { get; private set; }
        public Guid UploadedBy { get; private set; }
        public string FileName { get; private set; } = string.Empty;
        public string FileUrl { get; private set; } = string.Empty;
        public DateTime UploadedAt { get; private set; } = DateTime.UtcNow;

        // Audit fields
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public string? DeletedBy { get; private set; }

        private TeamFile() { } // EF Core

        public TeamFile(Guid teamId, Guid uploadedBy, string fileName, string fileUrl)
        {
            Id = Guid.NewGuid();
            TeamId = teamId;
            UploadedBy = uploadedBy;
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            FileUrl = fileUrl ?? throw new ArgumentNullException(nameof(fileUrl));
            UploadedAt = DateTime.UtcNow;
        }

        public void UpdateFile(string fileName, string fileUrl, string updatedBy)
        {
            FileName = fileName;
            FileUrl = fileUrl;
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
