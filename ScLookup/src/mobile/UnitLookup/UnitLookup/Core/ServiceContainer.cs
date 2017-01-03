using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitLookup.Services;

namespace UnitLookup.Core
{
    public class ServiceContainer
    {
        private static ServiceContainer _current;

        public static ServiceContainer Current
        {
            get
            {
                if (_current == null)
                    _current = new ServiceContainer();

                return _current;
            }
        }

        private ServiceContainer() { }

        // instance section
        // unit service
        private IUnitService _unitService;
        public IUnitService UnitService
        {
            get
            {
                if (_unitService == null)
                    _unitService = new UnitService();

                return _unitService;
            }
        }
    }
}
