using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Mapping;

public class AirplaneMapping : IEntityTypeConfiguration<Airplane>
{
    public void Configure(EntityTypeBuilder<Airplane> builder)
    {
        builder.ToTable("AirplaneInfo");

        builder.HasOne(a => a.Company).WithMany();

        builder.Property(c => c.Model).HasColumnName("AirplaneModel");

        builder.Property(c => c.Id).HasColumnName("CompanyID");
    }
}
