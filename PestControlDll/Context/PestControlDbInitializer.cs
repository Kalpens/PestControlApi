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
        }
    }
}
