using System;
using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    public class Video : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid LessonId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Url { get; private set; } = string.Empty;
        public TimeSpan Duration { get; private set; }
        public string? Transcript { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Video() { } // EF Core

        public Video(Guid lessonId, string title, string url, TimeSpan duration, string? transcript = null)
        {
            Id = Guid.NewGuid();
            LessonId = lessonId;
            Title = title;
            Url = url;
            Duration = duration;
            Transcript = transcript;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateDetails(string title, string url, TimeSpan duration, string? transcript)
        {
            Title = title;
            Url = url;
            Duration = duration;
            Transcript = transcript;
        }
    }
}
