using TalentFlow.Domain.Common;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Domain.Events
{
    public class TeamDiscussionCreatedEvent : DomainEvent
    {
        public TeamDiscussion Discussion { get; }

        public TeamDiscussionCreatedEvent(TeamDiscussion discussion)
        {
            Discussion = discussion;
        }
    }

    public class TeamDiscussionDeletedEvent : DomainEvent
    {
        public TeamDiscussion Discussion { get; }

        public TeamDiscussionDeletedEvent(TeamDiscussion discussion)
        {
            Discussion = discussion;
        }
    }

    public class TeamDiscussionUpdatedEvent : DomainEvent
    {
        public TeamDiscussion Discussion { get; }

        public TeamDiscussionUpdatedEvent(TeamDiscussion discussion)
        {
            Discussion = discussion;
        }
    }

    public class TeamDiscussionReplyAddedEvent : DomainEvent
    {
        public TeamDiscussion Reply { get; }

        public TeamDiscussionReplyAddedEvent(TeamDiscussion reply)
        {
            Reply = reply;
        }
    }
}
