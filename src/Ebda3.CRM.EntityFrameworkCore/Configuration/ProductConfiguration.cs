using Ebda3.CRM.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Ebda3.CRM.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ConfigureByConvention();
        
        builder.Property(x => x.Name)
            .HasMaxLength(ProductsConsts.MaxNameLength)
            .IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.ToTable("Product");
    }
}