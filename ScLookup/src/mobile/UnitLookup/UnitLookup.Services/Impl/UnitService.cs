using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnitLookup.Services.Models;

namespace UnitLookup.Services
{
    public class UnitService : IUnitService
    {
        public IList<Unit> _allUnits;
        public IDictionary<Guid, FullUnit> _unitCache;

        public UnitService()
        {
            _unitCache = new Dictionary<Guid, FullUnit>();
        }

        public IEnumerable<Unit> GetLoadedUnits()
        {
            if (_allUnits == null)
                return new List<Unit>();

            return _allUnits;
        }

        public async Task<FullUnit> GetUnitById(Guid unitId)
        {
            if (!_unitCache.ContainsKey(unitId))
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(string.Format("http://sclookup-dev.azurewebsites.net/api/Units/{0}", unitId));

                var client = new HttpClient();
                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                var unit = JsonConvert.DeserializeObject<FullUnit>(content);
                if (unit != null)
                {
                    _unitCache.Add(unitId, unit);
                    return unit;
                }

                return null;
            }
            else
            {
                return _unitCache[unitId];
            }
        }

        public async Task<bool> LoadAllUnitsAsync()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri("http://sclookup-dev.azurewebsites.net/api/Units/All");

                var client = new HttpClient();
                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                _allUnits = JsonConvert.DeserializeObject<IList<Unit>>(content);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
