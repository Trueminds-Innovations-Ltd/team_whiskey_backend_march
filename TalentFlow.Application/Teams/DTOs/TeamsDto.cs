using System;
using System.Collections.Generic;

namespace TalentFlow.Application.Teams.DTOs
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // List of learner IDs in the team
        public List<Guid> Members { get; set; } = new();
    }
}
