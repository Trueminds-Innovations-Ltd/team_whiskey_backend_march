using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;
using TalentFlow.Domain.Events;

namespace TalentFlow.Domain.Entities
{
    [Table("team_discussion")]
    public class TeamDiscussion : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid TeamId { get; private set; }
        public Guid UserId { get; private set; }
        public string Content { get; private set; } = string.Empty;

        // Audit fields
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public string? DeletedBy { get; private set; }

        // Replies
        private readonly List<TeamDiscussion> _replies = new();
        public IReadOnlyCollection<TeamDiscussion> Replies => _replies.AsReadOnly();

        private TeamDiscussion() { } // EF Core

        public TeamDiscussion(Guid teamId, Guid userId, string content)
        {
            Id = Guid.NewGuid();
            TeamId = teamId;
            UserId = userId;
            Content = content ?? throw new ArgumentNullException(nameof(content));
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new TeamDiscussionCreatedEvent(this));
        }

        public void AddReply(Guid userId, string content)
        {
            var reply = new TeamDiscussion(TeamId, userId, content);
            _replies.Add(reply);
            AddDomainEvent(new TeamDiscussionReplyAddedEvent(reply));
        }

        public void UpdateContent(string content, string updatedBy)
        {
            Content = content;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
            AddDomainEvent(new TeamDiscussionUpdatedEvent(this));
        }

        public void SoftDelete(string deletedBy)
        {
            IsDeleted = true;
            DeletedBy = deletedBy;
            DeletedAt = DateTime.UtcNow;
            AddDomainEvent(new TeamDiscussionDeletedEvent(this));
        }
    }
}
