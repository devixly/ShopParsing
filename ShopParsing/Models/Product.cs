using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopParsing.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Price> Prices { get; set; }
    }
}