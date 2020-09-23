using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stock.Entities.Dominio
{
    public class Product
    {
        [Key]
        public int ItemNo { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int InventoryCode { get; set; }
    }
}
