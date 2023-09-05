using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Mapping;

public class AirlineMapping : IEntityTypeConfiguration<Airline>
{
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        builder.ToTable("AirlineInfo");

        builder.HasOne(a => a.Country).WithMany();

        //builder.Property(a => a.Country).HasColumnName("CountryID");

        builder.Property(a => a.Name).HasColumnName("AirlineName");
    }
}
