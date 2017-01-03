using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScLookup.Models
{
    public class UnitDependency
    {
        [Key, Column(Order = 0)]
        [ForeignKey("TargetUnit")]
        public Guid TargetUnitId { get; set; }
        public Unit TargetUnit { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("DependentUnit")]
        public Guid DependentUnitId { get; set; }
        public Unit DependentUnit { get; set; }
    }
}