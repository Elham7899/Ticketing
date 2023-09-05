using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Mapping;

public class InformationMapping : IEntityTypeConfiguration<Information>
{
    public void Configure(EntityTypeBuilder<Information> builder)
    {
        builder.ToTable("Information");

        builder.Property(i => i.Location).HasColumnName("Category");
    }
}
