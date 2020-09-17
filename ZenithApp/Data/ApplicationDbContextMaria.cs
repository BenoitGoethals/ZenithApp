using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZenithApp.model;

namespace ZenithApp.Data
{
    public class ApplicationDbContextMaria : DbContext
    {
        private readonly IConfiguration _config;
        public ApplicationDbContextMaria(IConfiguration config, DbContextOptions<ApplicationDbContextMaria> options)
            : base(options)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

        }


        public DbSet<Basket> Baskets { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



        }
    }




}
