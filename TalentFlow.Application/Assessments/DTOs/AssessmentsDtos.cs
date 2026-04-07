using System;
using System.Collections.Generic;

namespace TalentFlow.Application.Assessments.DTOs
{
    public class AssessmentDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }   // Link back to the course
        public string Title { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Audit fields
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Questions belonging to this assessment
        public List<QuestionDto> Questions { get; set; } = new();
    }

    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
