using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketing.DAL.Mapping;

public class LinePlaneMapping : IEntityTypeConfiguration<LinePlane>
{
    public void Configure(EntityTypeBuilder<LinePlane> builder)
    {
        builder.HasMany(C => C.Cabins).WithOne();

        builder.HasOne(a => a.Airline).WithMany();

        builder.HasOne(a => a.Airplane).WithMany().HasForeignKey("AirplaneModelId");

        builder.ToTable("LinePlane");
    }
}
