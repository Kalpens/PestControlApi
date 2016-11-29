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
    class UserRepository : IRepository<User>
    {
        public User Create(User c)
        {
            using (var db = new PestControlContext())
            {
                db.User.Add(c);
                db.SaveChanges();
                return c;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new PestControlContext())
            {
                db.Entry(db.User.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                db.SaveChanges();
                return db.User.FirstOrDefault(x => x.Id == id) == null;
            }
        }

        public List<User> Read()
        {
            using (var db = new PestControlContext())
            {
                return db.User.ToList();
            }
        }

        public User Read(int id)
        {
            using (var db = new PestControlContext())
            {
                return db.User.FirstOrDefault(x => x.Id == id);
            }
        }

        public User Update(User c)
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
