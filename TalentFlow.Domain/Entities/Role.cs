using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    [Table("role")] // plural is conventional
    public class Role : EntityBase
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        private readonly List<User> _users = new();
        public IReadOnlyCollection<User> Users => _users.AsReadOnly();

        private Role() { } // EF Core

        // ✅ Constructor for seeding
        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        // Normal constructor for runtime use
        public Role(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void AssignUser(User user) => _users.Add(user);
    }
}
