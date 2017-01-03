using System;
using System.Collections.Generic;

namespace ScLookup.Api.ResponseModels
{
    public class FullUnitResponse : UnitResponse
    {
        public UnitResponse ProducingUnit { get; set; }
        public IList<UnitResponse> DependsOn { get; set; }
    }
}