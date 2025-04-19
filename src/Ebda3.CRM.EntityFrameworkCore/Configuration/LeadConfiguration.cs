using Ebda3.CRM.Leads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Ebda3.CRM.Configuration;

public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(x => x.FirstName)
            .HasMaxLength(LeadConsts.MaxNameLength)
            .IsRequired();
        
        builder.Property(x => x.LastName)
            .HasMaxLength(LeadConsts.MaxNameLength)
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasMaxLength(LeadConsts.MaxEmailLength)
            .IsRequired();
        
        builder.Property(x => x.Phone)
            .HasMaxLength(LeadConsts.MaxPhoneLength);

        builder.OwnsOne(p => p.Address, a =>
        {
            a.Property(x => x.Street)
                .HasColumnName("Street")
                .HasMaxLength(LeadConsts.MaxStreetLength)
                .IsRequired();
            
            a.Property(x => x.City)
                .HasColumnName("City")
                .HasMaxLength(LeadConsts.MaxCityLength)
                .IsRequired();
            
            a.Property(x => x.State)
                .HasColumnName("State")
                .HasMaxLength(LeadConsts.MaxStateLength)
                .IsRequired();
            
            a.Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .HasMaxLength(LeadConsts.MaxZipCodeLength)
                .IsRequired(false);
        });
        
        builder.Property(x => x.Camponey)
            .HasMaxLength(LeadConsts.MaxCompanyLength)
            .IsRequired();
        
        builder.Property(x => x.Industry)
            .HasMaxLength(LeadConsts.MaxIndustryLength)
            .IsRequired();
        
        builder.Property(x => x.Status)
            .IsRequired();
        
        builder.Property(x => x.Source)
            .IsRequired();
        
        builder.Property(x => x.AssignedTo)
            .HasMaxLength(LeadConsts.MaxNameLength)
            .IsRequired(false);
        
        builder.ToTable(LeadConsts.TableName);
    }
}