using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Mapping;

public class ContinentMapping : IEntityTypeConfiguration<Continent>
{
    public void Configure(EntityTypeBuilder<Continent> builder)
    {
        builder.ToTable("Continent");

        builder.Property("Name").HasColumnName("ContinentName");
    }
}
