using System;

namespace TalentFlow.Application.Progresses.DTOs
{
    public class ProgressDto
    {
        public Guid Id { get; set; }
        public Guid LearnerId { get; set; }
        public Guid CourseId { get; set; }
        public Guid? LessonId { get; set; }
        public double PercentageCompleted { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}
