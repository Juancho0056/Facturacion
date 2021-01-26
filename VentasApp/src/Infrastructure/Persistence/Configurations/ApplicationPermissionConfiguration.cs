using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VentasApp.Domain.Entities.Application;

namespace VentasApp.Infrastructure.Persistence.Configurations
{
    public class ApplicationPermissionConfiguration : IEntityTypeConfiguration<ApplicationPermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationPermission> builder)
        {
            builder.Property(t => t.Id)
                .IsRequired();
            builder.Property(t => t.Detalle)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);
            builder.Property(t => t.Slug)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);
            builder.HasOne(t => t.MenuRole)
                   .WithMany()
                   .HasForeignKey(s => s.MenuRoleId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
