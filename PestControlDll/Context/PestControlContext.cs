using PestControlDll.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControlDll.Context
{
    public class PestControlContext : DbContext
    {
        public PestControlContext() : base()
        {
            Database.SetInitializer(new PestControlDbInitializer());
        }

        public DbSet<Destination> Destination { get; set; }
        public DbSet<PestType> PestType { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Worksheet> Worksheet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
