using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FutGame.Model
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }
        public long TeamId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
    
}
