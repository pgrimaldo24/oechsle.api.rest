using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oechsle.Api.Domain.Models;

namespace Oechsle.Api.Infraestructure.Implementations.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> entityTypeBuilder)
        {
            entityTypeBuilder.Property(e => e.Id).HasColumnName("id");

            entityTypeBuilder.Property(e => e.Age).HasColumnName("age");

            entityTypeBuilder.Property(e => e.DocumentNumber)
                .HasMaxLength(10)
                .HasColumnName("document_number");

            entityTypeBuilder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entityTypeBuilder.Property(e => e.ProfileImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image");

            entityTypeBuilder.Property(e => e.Salary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salary");
        }
    }
}
