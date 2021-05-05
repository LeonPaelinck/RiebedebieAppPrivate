using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiebedebieApi.Models;
using System;

namespace RiebedebieApi.Data.Mappers
{
    public class RiebedebieConfiguration : IEntityTypeConfiguration<Riebedebie>
    {
        public void Configure(EntityTypeBuilder<Riebedebie> builder)
        {
            builder.HasMany(r => r.Reservations).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
