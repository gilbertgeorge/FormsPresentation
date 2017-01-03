using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScLookup.Models
{
    public class UnitProduction
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Unit")]
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("ProducedBy")]
        public Guid ProducedById { get; set; }
        public Unit ProducedBy { get; set; }

        public ProductionAction Action { get; set; }
    }
}