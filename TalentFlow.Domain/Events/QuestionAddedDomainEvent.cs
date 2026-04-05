using TalentFlow.Domain.Common;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Domain.Events
{
    /// <summary>
    /// Domain event raised when a new question is added to an assessment.
    /// </summary>
    public class QuestionAddedDomainEvent : DomainEvent
    {
        public Assessment Assessment { get; }
        public Question Question { get; }

        public QuestionAddedDomainEvent(Assessment assessment, Question question)
            : base()
        {
            Assessment = assessment;
            Question = question;
        }
    }
}
