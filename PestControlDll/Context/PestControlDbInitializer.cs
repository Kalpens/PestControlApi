using PestControlDll.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControlDll.Context
{
    public class PestControlDbInitializer : CreateDatabaseIfNotExists<PestControlContext>
    {
        protected override void Seed(PestControlContext context)
        {
            base.Seed(context);
            context.User.Add(new User
            {
                Address = "PlzGiveme12Street",
                Email = "IWorkedHard@Seriously.plz",
                FullName = "Mc WorksAlot",
                LicensePlate = "PU 15 548",
                UserType = User.UserTypeEnum.Admin
            });

            context.Route.Add(new Route()
            {
                Name = "Just day",
                Date = DateTime.Now
            });

            context.Route.Add(new Route()
            {
                Name = "Tuesday",
                Date = DateTime.Now
            });

            context.Route.Add(new Route()
            {
                Name = "Santa's route"
            });

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

        }
    }
}
