using TalentFlow.Domain.Common;
using TalentFlow.Domain.Events;

namespace TalentFlow.Domain.Entities
{
    public class Assessment : EntityBase
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Instructions { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<Question> _questions = new();
        public IReadOnlyCollection<Question> Questions => _questions.AsReadOnly();

        private Assessment() { } // EF Core

        public Assessment(string title, string instructions)
        {
            Id = Guid.NewGuid();
            Title = title;
            Instructions = instructions;
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new AssessmentCreatedDomainEvent(this));
        }

        public void AddQuestion(string text, string answer)
        {
            var question = new Question(Id, text, answer);
            _questions.Add(question);

            AddDomainEvent(new QuestionAddedDomainEvent(this, question));
        }
    }
}
