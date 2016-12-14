using PestControlDll.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControlDll.Context
{
    public class PestControlDbInitializer : DropCreateDatabaseIfModelChanges<PestControlContext>
    {
        protected override void Seed(PestControlContext context)
        {
            var u1 = new User
            {
                Address = "PlzGiveme12Street",
                Email = "IWorkedHard@Seriously.plz",
                FullName = "Mc WorksAlot",
                LicensePlate = "PU 15 548",
                UserType = User.UserTypeEnum.Admin,
                Routes = new List<Route>()
            };
            var r1 = new Route()
            {
                Name = "Just a day",
                Date = DateTime.Now,
                UserId = 1,
                User = u1,
                Destinations = new List<Destination>()
            };

            var r2 = new Route()
            {
                Name = "Tuesday",
                Date = DateTime.Now,
                UserId = 1,
                User = u1,
                Destinations = new List<Destination>()
            };
            context.Route.Add(r1);
            context.Route.Add(r2);
            u1.Routes.Add(r1);
            u1.Routes.Add(r2);
            context.User.Add(u1);

            context.PestType.Add(new PestType()
            {
                Name = "Hvepse/Bier"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Bier"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Myrer"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Mus"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Lopper"
            });

            context.PestType.Add(new PestType()
            {
                Name = "1 beh. Muldvarpe"
            });

            context.PestType.Add(new PestType()
            {
                Name = "3 beh. Muldvarpe"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Væggelus"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Sølvfisk"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Kakerlakker"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Møl"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Mårsikring"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Mårtjek"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Rotter"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Mår"
            });

            context.PestType.Add(new PestType()
            {
                Name = "Andet"
            });
            base.Seed(context);
        }
    }
}
