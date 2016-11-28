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
            base.Seed(context)
        }
    }
}
