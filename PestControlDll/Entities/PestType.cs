using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControlDll.Entities
{
    public class PestType : AbstractEntity
    {
        public PestType()
        {
            this.Worksheets = new List<Worksheet>();
        }
        public string Name { get; set; }
        
        public List<Worksheet> Worksheets { get; set; }
    }
}
