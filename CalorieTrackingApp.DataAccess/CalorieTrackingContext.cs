using CalorieTrackingApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.DataAccess
{
    public class CalorieTrackingContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-AV372PO\SQLEXPRESS;Database=CalorieTrackingDb;integrated security=true;");
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Calculator> Calculators { get; set; }
    }
}
