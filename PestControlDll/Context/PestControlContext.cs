using PestControlDll.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControlDll.Repositories;

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
            modelBuilder.Entity<Route>()
                .HasRequired<User>(u => u.User)
                .WithMany(u => u.Routes)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Destination>()
                .HasRequired<Route>(r => r.Route)
                .WithMany(r => r.Destinations)
                .HasForeignKey(r => r.RouteId);

            modelBuilder.Entity<Destination>()
                .HasOptional(w => w.Worksheet)
                .WithRequired(d => d.Destination);

            modelBuilder.Entity<Worksheet>()
                .HasMany<PestType>(w => w.PestTypes)
                .WithMany(p => p.Worksheets)
                .Map(pw =>
                    {
                        pw.MapLeftKey("WorksheetRefId");
                        pw.MapRightKey("PestTypeRefId");
                        pw.ToTable("WorksheetPestTypes");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}
