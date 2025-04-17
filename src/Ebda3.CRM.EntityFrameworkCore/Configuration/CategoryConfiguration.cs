using Ebda3.CRM.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Ebda3.CRM.Configuration;

public class CategoryConfiguration :
    IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ConfigureByConvention();
        
        builder.HasIndex(x => x.Name);
        builder.Property(x => x.Name)
            .HasMaxLength(CategoryConsts.MaxNameLength).IsRequired();

        builder.ToTable("Category");
    }
}