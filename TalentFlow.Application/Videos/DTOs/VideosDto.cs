using System;

namespace TalentFlow.Application.Videos.DTOs
{
    public class VideoDto
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public string? Transcript { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
