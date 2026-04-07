using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    public class Question : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid AssessmentId { get; private set; }
        public string Text { get; private set; } = string.Empty;
        public string Answer { get; private set; } = string.Empty;

        private Question() { } // EF Core

        public Question(Guid assessmentId, string text, string answer)
        {
            Id = Guid.NewGuid();
            AssessmentId = assessmentId;
            Text = text;
            Answer = answer;
        }

        public void Update(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }
    }
}
