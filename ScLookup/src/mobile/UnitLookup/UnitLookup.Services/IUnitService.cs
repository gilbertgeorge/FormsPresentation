using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitLookup.Services.Models;

namespace UnitLookup.Services
{
    public interface IUnitService
    {
        Task<bool> LoadAllUnitsAsync();
        IEnumerable<Unit> GetLoadedUnits();
        Task<FullUnit> GetUnitById(Guid unitId);
    }
}
