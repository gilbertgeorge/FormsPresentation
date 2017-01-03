using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitLookup.Services.Models
{
    public class FullUnit
    {
        [JsonProperty]
        public Guid UnitId { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public UnitFaction UnitFaction { get; set; }

        [JsonProperty("Type")]
        public UnitType UnitType { get; set; }

        [JsonProperty]
        public int HitPoints { get; set; }

        [JsonProperty]
        public int ShieldPoints { get; set; }

        [JsonProperty]
        public int MineralCost { get; set; }

        [JsonProperty]
        public int GasCost { get; set; }

        [JsonProperty]
        public IList<Unit> DependsOn { get; set; }

        [JsonProperty]
        public Unit ProducingUnit { get; set; }
    }
}
