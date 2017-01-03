using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsTest.Models
{
    public class StarcraftFaction
    {
        public FactionEnum Faction { get; set; }
        public string Name { get { return Faction.ToString(); } }

        public StarcraftFaction(FactionEnum faction)
        {
            Faction = faction;
        }
    }

    public enum FactionEnum
    {
        Terran,
        Zerg,
        Protoss
    }
}
