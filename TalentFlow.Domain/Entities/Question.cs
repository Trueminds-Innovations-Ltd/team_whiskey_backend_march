using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    public class Question : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid AssessmentId { get; private set; }
        public string Text { get; private set; }
        public string Answer { get; private set; }

        private Question() { } // EF Core

        public Question(Guid assessmentId, string text, string answer)
        {
            Id = Guid.NewGuid();
            AssessmentId = assessmentId;
            Text = text;
            Answer = answer;
        }
    }
}
