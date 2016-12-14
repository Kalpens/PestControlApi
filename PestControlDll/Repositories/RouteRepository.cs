using PestControlDll.Context;
using PestControlDll.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControlDll.Repositories
{
    class RouteRepository : IRepository<Route>
    {
        public Route Create(Route t)
        {
            using (var db = new PestControlContext())
            {
                db.Route.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new PestControlContext())
            {
                List<Destination> destinations = new DllFacade().GetDestinationRepository().Read();
                List<Destination> toBeDeletedDestinations = destinations.Where(x => x.RouteId == id).ToList();
                foreach (var item in toBeDeletedDestinations)
                {
                    new DestinationRepository().Delete(item.Id);
                }
                db.Entry(db.Route.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
                return db.Route.FirstOrDefault(x => x.Id == id) == null;
            }
        }

        public List<Route> Read()
        {
            using (var db = new PestControlContext())
            {
                return db.Route.ToList();
            }
        }

        public Route Read(int id)
        {
            using (var db = new PestControlContext())
            {
                return db.Route.FirstOrDefault(x => x.Id == id);
            }
        }

        public Route Update(Route c)
        {
            using (var db = new PestControlContext())
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return c;
            }
        }
    }
}
