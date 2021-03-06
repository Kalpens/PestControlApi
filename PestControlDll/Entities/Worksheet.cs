﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControlDll.Entities
{
    public class Worksheet
    {
        public Worksheet()
        {
            this.PestTypes = new List<PestType>();
        }
        public string Date { get; set; }
        public string PhoneNumber { get; set; } //It's a string so we can add +xx depending on where he is in the country
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostNumber { get; set; }
        public string Email { get; set; }
        public string EAN_Number { get; set; }
        public string RekvNumber { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public Boolean ReVisited { get; set; }
        public List<PestType> PestTypes { get; set; }
        //Enums associated its value with ordered numbers, starting from 0.
        //TaxNoTax == 1 means that there are NoTax.
        public enum TaxNoTaxEnum { Tax, NoTax };
        public TaxNoTaxEnum TaxNoTax { get; set; }

        public Destination Destination { get; set; }
        [Key, ForeignKey("Destination")]
        public int DestinationId { get; set; }
    }
}
