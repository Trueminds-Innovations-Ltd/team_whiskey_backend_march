using System;
using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    [Table("progresss")] // matches EF query
    public class Progress : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid LearnerId { get; private set; }
        public Guid CourseId { get; private set; }
        public Guid? LessonId { get; private set; }
        public double PercentageCompleted { get; private set; }
        public DateTime LastAccessed { get; private set; }

        public Progress(Guid learnerId, Guid courseId, Guid? lessonId = null)
        {
            Id = Guid.NewGuid();
            LearnerId = learnerId;
            CourseId = courseId;
            LessonId = lessonId;
            PercentageCompleted = 0;
            LastAccessed = DateTime.UtcNow;
        }

        public void UpdateProgress(double percentage)
        {
            PercentageCompleted = percentage;
            LastAccessed = DateTime.UtcNow;
        }
    }
}
