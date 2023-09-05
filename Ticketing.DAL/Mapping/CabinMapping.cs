using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Mapping;

public class CabinMapping : IEntityTypeConfiguration<Cabin>
{
    public void Configure(EntityTypeBuilder<Cabin> builder)
    {
        builder.ToTable("Cabins");

        builder.Property(x => x.CabinClass).HasColumnName("CabinClassID");

        builder.Property(x => x.Seat).HasColumnName("CountOfSeats");
    }
}
