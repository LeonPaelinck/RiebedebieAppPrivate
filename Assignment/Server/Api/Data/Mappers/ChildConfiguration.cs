using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiebedebieApi.Models;
using System;

namespace RiebedebieApi.Data.Mappers
{
    public class ChildConfiguration : IEntityTypeConfiguration<Child>
    {

        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder.Property(k => k.LastName).IsRequired().HasMaxLength(50);
            builder.Property(k => k.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(k => k.BirthDate).IsRequired();
        }
    }
}
