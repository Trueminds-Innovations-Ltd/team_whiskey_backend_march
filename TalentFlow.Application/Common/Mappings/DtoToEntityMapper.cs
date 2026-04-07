using System;
using TalentFlow.Domain.Entities;
using TalentFlow.Application.Assessments.DTOs;
using TalentFlow.Application.Progresses.DTOs;
using TalentFlow.Application.Lessons.DTOs;
using TalentFlow.Application.Teams.DTOs;
using TalentFlow.Application.Certificates.DTOs;
using TalentFlow.Application.Videos.DTOs;
using TalentFlow.Application.Notifications.DTOs;

namespace TalentFlow.Application.Common.Mappings
{
    public static class DtoToEntityMapper
    {
        public static Assessment ToEntity(this AssessmentDto dto)
        {
            var assessment = new Assessment(dto.CourseId, dto.Title, dto.Instructions);
            foreach (var q in dto.Questions)
            {
                assessment.AddQuestion(q.Text, q.Answer);
            }
            return assessment;
        }

        public static Progress ToEntity(this ProgressDto dto)
        {
            var progress = new Progress(dto.LearnerId, dto.CourseId, dto.LessonId);
            progress.UpdateProgress(dto.PercentageCompleted);
            return progress;
        }

        public static Lesson ToEntity(this LessonDto dto)
        {
            return new Lesson(dto.CourseId, dto.Title, dto.Content, dto.Order, dto.Duration);
        }

        public static Team ToEntity(this TeamDto dto)
        {
            var team = new Team(dto.Name);
            foreach (var member in dto.Members)
            {
                team.AddMember(member);
            }
            return team;
        }

        public static Certificate ToEntity(this CertificateDto dto)
        {
            return new Certificate(dto.LearnerId, dto.CourseId, dto.IssuedBy, dto.ExpiresAt);
        }

        public static Video ToEntity(this VideoDto dto)
        {
            return new Video(dto.LessonId, dto.Title, dto.Url, dto.Duration, dto.Transcript);
        }

        public static Notification ToEntity(this NotificationDto dto)
        {
            var notification = new Notification(dto.UserId, dto.Message);
            if (dto.IsDeleted)
            {
                notification.SoftDelete(dto.DeletedBy ?? "system");
            }
            return notification;
        }
    }
}
