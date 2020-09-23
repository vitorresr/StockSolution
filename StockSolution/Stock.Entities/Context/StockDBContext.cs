using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Stock.Entities.Dominio;

namespace Stock.Entities.Context
{
    public class StockDBContext : DbContext
    {
        public StockDBContext(DbContextOptions<StockDBContext> options) : base(options) { }
        public virtual DbSet<Product> Products { get; set; }
    }
}
