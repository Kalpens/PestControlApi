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
    class WorksheetRepository : IRepository<Worksheet>
    {
        public Worksheet Create(Worksheet c)
        {
            using (var db = new PestControlContext())
            {
                db.Worksheet.Add(c);
                db.SaveChanges();
                return c;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new PestControlContext())
            {
                db.Entry(db.Worksheet.FirstOrDefault(x => x.DestinationId == id)).State = EntityState.Deleted;
                db.SaveChanges();
                return db.Worksheet.FirstOrDefault(x => x.DestinationId == id) == null;
            }
        }

        public List<Worksheet> Read()
        {
            using (var db = new PestControlContext())
            {
                return db.Worksheet.ToList();
            }
        }

        public Worksheet Read(int id)
        {
            using (var db = new PestControlContext())
            {
                return db.Worksheet.FirstOrDefault(x => x.DestinationId == id);
            }
        }

        public Worksheet Update(Worksheet c)
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
