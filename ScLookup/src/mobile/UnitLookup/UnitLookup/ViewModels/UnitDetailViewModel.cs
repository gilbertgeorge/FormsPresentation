using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitLookup.Services.Models;

namespace UnitLookup.ViewModels
{
    public class UnitDetailViewModel
    {
        public FullUnit FullUnit { get; private set; }

        public bool HasShields
        {
            get { return FullUnit.ShieldPoints > 0; }
        }

        public string Name
        {
            get { return FullUnit.Name; }
        }

        public int HitPoints
        {
            get { return FullUnit.HitPoints; }
        }

        public int MineralCost
        {
            get { return FullUnit.MineralCost; }
        }

        public int GasCost
        {
            get { return FullUnit.GasCost; }
        }

        public int ShieldPoints
        {
            get { return FullUnit.ShieldPoints; }
        }

        public string UnitType
        {
            get { return FullUnit.UnitType.ToString(); }
        }

        public string ProducingUnitName
        {
            get { return FullUnit.ProducingUnit.Name; }
        }

        public bool HasDependencies
        {
            get { return FullUnit.DependsOn.Count > 0; }
        }

        public IList<Unit> UnitDependencies
        {
            get { return FullUnit.DependsOn.ToList(); }
        }

        public UnitDetailViewModel(FullUnit fullUnit)
        {
            FullUnit = fullUnit;
        }
    }
}
