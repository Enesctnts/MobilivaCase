using Microsoft.EntityFrameworkCore;
using MobilivaCase.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.DataAccess.Context
{
    public class MobilivaDbContext : DbContext
    {
        public MobilivaDbContext(DbContextOptions<MobilivaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Çalışan assembly üzerindeki tüm config ifadelerini dikkate al
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
