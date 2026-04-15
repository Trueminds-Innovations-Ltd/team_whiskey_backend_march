using System;
using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;
using TalentFlow.Domain.Events;

namespace TalentFlow.Domain.Entities
{
    [Table("grade")]
    public class Grade : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid SubmissionId { get; private set; }
        public Guid InstructorId { get; private set; }
        public decimal Score { get; private set; }
        public string Rubric { get; private set; } = string.Empty; // JSON or structured text
        public string Comments { get; private set; } = string.Empty;

        // Audit fields
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        private Grade() { } // EF Core

        public Grade(Guid submissionId, Guid instructorId, decimal score, string rubric, string comments)
        {
            Id = Guid.NewGuid();
            SubmissionId = submissionId;
            InstructorId = instructorId;
            Score = score;
            Rubric = rubric ?? string.Empty;
            Comments = comments ?? string.Empty;
            CreatedAt = DateTime.UtcNow;

            // Raise domain event
            AddDomainEvent(new GradeCreatedEvent(this));
        }

        public void Update(decimal score, string rubric, string comments, string updatedBy)
        {
            Score = score;
            Rubric = rubric;
            Comments = comments;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;

            // Raise domain event
            AddDomainEvent(new GradeUpdatedEvent(this));
        }
    }
}
