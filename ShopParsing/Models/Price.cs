using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopParsing.Models
{
    public class Price
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public decimal OfferPrice { get; set; }
        public DateTime Date { get; set; }

        public virtual Product Product { get; set; }
    }
}