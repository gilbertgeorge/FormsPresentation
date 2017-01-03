using ScLookup.Models.Context;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using ScLookup.Api.ResponseModels;
using ScLookup.Models;
using System;
using System.Data.Entity;

namespace ScLookup.Api.Controllers
{
    [RoutePrefix("api/Units")]
    public class UnitsController : ApiController
    {
        public IContext DataContext { get; private set; }

        public UnitsController(IContext context)
        {
            DataContext = context;
        }

        [Route("all")]
        [HttpGet]
        public IList<UnitResponse> GetAll()
        {
            return DataContext.Units.OrderBy(x => x.Name).Select(x => new UnitResponse
            {
                UnitId = x.Id,
                Name = x.Name,
                Faction = x.Faction,
                UnitType = x.UnitType
            }).ToList();
        }

        [Route("all/{faction}")]
        [HttpGet]
        public IList<UnitResponse> GetForFaction(UnitFaction faction)
        {
            return DataContext.Units.Where(x => x.Faction == faction)
                .OrderBy(x => x.Name)
                .Select(x => new UnitResponse
                {
                    UnitId = x.Id,
                    Name = x.Name,
                    Faction = faction,
                    UnitType = x.UnitType
                }).ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public FullUnitResponse Get(Guid id)
        {
            var unit = DataContext.Units
                .Include(x => x.Dependencies.Select(x1 => x1.DependentUnit))
                .Include(x => x.Production)
                .Include(x => x.Production.ProducedBy)
                .FirstOrDefault(x => x.Id == id);

            if (unit == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            return new FullUnitResponse
            {
                UnitId = unit.Id,
                Name = unit.Name,
                Faction = unit.Faction,
                UnitType = unit.UnitType,
                ProducingUnit = new UnitResponse
                {
                    UnitId = unit.Production.ProducedById,
                    Name = unit.Production.ProducedBy.Name,
                    Faction = unit.Faction,
                    UnitType = unit.Production.ProducedBy.UnitType
                },
                DependsOn = unit.Dependencies.Select(x => new UnitResponse
                {
                    UnitId = x.DependentUnitId,
                    Name = x.DependentUnit.Name,
                    Faction = unit.Faction,
                    UnitType = x.DependentUnit.UnitType
                }).ToList()
            };
        }
    }
}
