using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketing.DAL.Contract.Models;

namespace Ticketing.DAL.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.ContactInformation).WithOne();

        builder.HasOne(u=>u.Nationality).WithMany();

        builder.Property(u => u.Gender1).HasColumnName("Gender");
    }
}
