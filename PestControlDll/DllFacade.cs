using PestControlDll.Entities;
using PestControlDll.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControlDll
{
    public class DllFacade
    {
        public IRepository<Destination> GetDestinationRepository()
        {
            return new DestinationRepository();
        }

        public IRepository<PestType> GetPestTypeRepository()
        {
            return new PestTypeRepository();
        }

        public IRepository<Route> GetRouteRepository()
        {
            return new RouteRepository();
        }

        public IRepository<User> GetUserRepository()
        {
            return new UserRepository();
        }

        public IRepository<Worksheet> GetWorksheetRepository()
        {
            return new WorksheetRepository();
        }
    }
}
