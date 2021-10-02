using BlazorSecurityDemo.Shared;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSecurityDemo.Data
{
    public class CounterContext : DbContext
    {
        public CounterContext(DbContextOptions<CounterContext> options)
    : base(options)
        {

        }

        public CounterContext()
        {

        }

        public DbSet<CurrentCount> CurrentCount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=TotallyNotSmartPayDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=localhost;Database=BlazorSecurityDemo;Trusted_Connection=True;");//work
            base.OnConfiguring(optionsBuilder);
        }
    }
}
