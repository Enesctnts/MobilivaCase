using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobilivaCase.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.DataAccess.Config
{
    public class ProductContif : IEntityTypeConfiguration<Product>
    {
        //Fake data üretimi 
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                 new Faker<Product>()
                .RuleFor(x => x.Category, a => a.Commerce.ProductName())
                .RuleFor(x => x.CreateDate, a => a.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now))
                .RuleFor(x => x.Description, a => a.Name.FullName())
                .RuleFor(x => x.Status, true)
                .RuleFor(x => x.Unit, a => a.Random.Int(1, 10))
                .RuleFor(x => x.UnitPrice, a => a.Random.Decimal())
                .Generate(1000)
            );
        }
    }
}
