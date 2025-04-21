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
        
        builder.OwnsOne(p => p.ContactInfo, c =>
        {
            c.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(LeadConsts.MaxEmailLength)
                .IsRequired();
            
            c.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(LeadConsts.MaxPhoneLength)
                .IsRequired();
        });
        
        builder.Property(x => x.Company)
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