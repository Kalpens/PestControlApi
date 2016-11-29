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
    class PestTypeRepository : IRepository<PestType>
    {
        public PestType Create(PestType c)
        {
            using (var db = new PestControlContext())
            {
                db.PestType.Add(c);
                db.SaveChanges();
                return c;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new PestControlContext())
            {
                db.Entry(db.PestType.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
                return db.PestType.FirstOrDefault(x => x.Id == id) == null;
            }
        }

        public List<PestType> Read()
        {
            using (var db = new PestControlContext())
            {
                return db.PestType.ToList();
            }
        }

        public PestType Read(int id)
        {
            using (var db = new PestControlContext())
            {
                return db.PestType.FirstOrDefault(x => x.Id == id);
            }
        }

        public PestType Update(PestType c)
        {
            using (var db = new PestControlContext())
            {
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return c;
            }
        }
    }
}
