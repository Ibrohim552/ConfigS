using EFcoreWebAPi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcoreWebAPi.EntitiesConfigurations;

public class DoctorsConfig:IEntityTypeConfiguration<Doctors>
{
    public void Configure(EntityTypeBuilder<Doctors> builder)
    {
        builder.ToTable("Doctors");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(13).IsRequired();
        builder.HasQueryFilter(x => x.BirthDay > 18);
            
    }
}