using System;
using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    [Table("helpful_mark")]
    public class HelpfulMark : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid DiscussionId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime MarkedAt { get; private set; } = DateTime.UtcNow;

        private HelpfulMark() { } // EF Core

        public HelpfulMark(Guid discussionId, Guid userId)
        {
            Id = Guid.NewGuid();
            DiscussionId = discussionId;
            UserId = userId;
            MarkedAt = DateTime.UtcNow;
        }
    }
}
