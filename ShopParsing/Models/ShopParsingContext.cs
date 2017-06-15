using System.Data.Entity;

namespace ShopParsing.Models
{
    public class ShopParsingContext : DbContext
    {
        public ShopParsingContext(): base("DatabaseConnection")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}