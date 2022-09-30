using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oechsle.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oechsle.Api.Infraestructure.Implementations.Configuration
{
    public class KeyAppConfiguration : IEntityTypeConfiguration<KeyappEntity>
    {
        public void Configure(EntityTypeBuilder<KeyappEntity> builder)
        {
            builder.ToTable("keyapp");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Flag)
                .HasColumnName("flag")
                .HasDefaultValueSql("1"); 

            builder.Property(e => e.User)
               .HasMaxLength(200)
               .HasColumnName("user");

            builder.Property(e => e.Password)
               .HasMaxLength(200)
               .HasColumnName("password");

             

        }
    }
}
