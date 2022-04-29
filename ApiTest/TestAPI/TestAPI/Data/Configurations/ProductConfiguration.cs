using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Data.Entities;

namespace TestAPI.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.Property(x => x.CategoryId).IsRequired(false);
            builder.Property(x => x.CostPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SalePrice).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Category).WithMany(x => x.Products).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
