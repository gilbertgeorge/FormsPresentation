using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScLookup.Models
{
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int ShieldPoints { get; set; }
        public int MineralCost { get; set; }
        public int GasCost { get; set; }
        public int BuildTime { get; set; }
        public UnitFaction Faction { get; set; }
        public UnitType UnitType { get; set; }

        public UnitProduction Production { get; set; }
        public virtual ICollection<UnitProduction> UnitsProduced { get; set; }
        public virtual ICollection<UnitDependency> Dependencies { get; set; }
    }
}