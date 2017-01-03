using ScLookup.Models;
using Newtonsoft.Json;
using System;

namespace ScLookup.Api.ResponseModels
{
    public class UnitResponse
    {
        public Guid UnitId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public UnitFaction Faction { get; set; }
        [JsonIgnore]
        public UnitType UnitType { get; set; }

        public string UnitFaction
        {
            get { return Faction.ToString();  }
        }

        public string Type
        {
            get { return UnitType.ToString(); }
        }
    }
}