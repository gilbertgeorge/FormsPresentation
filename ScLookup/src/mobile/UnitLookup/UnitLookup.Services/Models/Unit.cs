using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitLookup.Services.Models
{
    public class Unit
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public Guid UnitId { get; set; }

        [JsonProperty]
        public UnitFaction UnitFaction { get; set; }

        [JsonProperty("Type")]
        public UnitType UnitType { get; set; }
    }
}
