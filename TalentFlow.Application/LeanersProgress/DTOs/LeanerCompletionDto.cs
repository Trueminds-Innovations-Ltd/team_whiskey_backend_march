using System;
using System.Collections.Generic;
using System.Text;

namespace TalentFlow.Application.LeanersProgress.DTOs
{
    public class LeanerCompletionDto
    {
        public DateTime CompletedAt { get; set; }
        public Guid? NextLessonId { get; set; }
        public decimal CoursePercentage { get; set; }
    }
}
