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
    class DestinationRepository : IRepository<Destination>
    {
        public Destination Create(Destination t)
        {
            using (var db = new PestControlContext())
            {
                db.Destination.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new PestControlContext())
            {
                db.Entry(db.Destination.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
                return db.Destination.FirstOrDefault(x => x.Id == id) == null;
            }
        }

        public List<Destination> Read()
        {
            using (var db = new PestControlContext())
            {
                return db.Destination.ToList();
            }
        }

        public Destination Read(int id)
        {
            using (var db = new PestControlContext())
            {
                return db.Destination.FirstOrDefault(x => x.Id == id);
            }
        }

        public Destination Update(Destination t)
        {
            using (var db = new PestControlContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }
    }
}
