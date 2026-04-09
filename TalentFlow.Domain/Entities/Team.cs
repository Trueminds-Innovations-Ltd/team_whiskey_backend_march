using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    [Table("Team")] // matches EF query

    public class Team : EntityBase
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

        private readonly List<Guid> _members = new();
        public IReadOnlyCollection<Guid> Members => _members.AsReadOnly();

        public Team(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddMember(Guid learnerId)
        {
            if (!_members.Contains(learnerId))
                _members.Add(learnerId);
        }

        public void RemoveMember(Guid learnerId)
        {
            _members.Remove(learnerId);
        }
    }
}
