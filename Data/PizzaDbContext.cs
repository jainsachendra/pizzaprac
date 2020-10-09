using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class PizzaDbContext: DbContext
    {
        public DbSet<PizzaDetails> pizzaDetails { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {

        }
    }
}
