using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FutGame.Model.Entities
{
    public class Player
    {
        public long PlayerId { get; set; }
        public string Name   { get; set; }
        public string RealTeam { get; set; }
        public int DisplayLevel { get; set; }
        public string CalculatedLevel { get; set; }
        public Position Position { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }

    public enum Position
    {
        GoalKeeper = 1,
        Defender = 2,
        FullBack = 3,
        Midfielder = 4,
        Forward = 5
    }
}
