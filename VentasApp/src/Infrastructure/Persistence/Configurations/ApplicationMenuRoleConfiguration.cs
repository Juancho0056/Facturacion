using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VentasApp.Domain.Entities.Application;

namespace VentasApp.Infrastructure.Persistence.Configurations
{
    public class ApplicationMenuRoleConfiguration : IEntityTypeConfiguration<ApplicationMenuRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationMenuRole> builder)
        {
            builder.HasOne(t => t.Role)
             .WithMany()
             .HasForeignKey(s => s.RoleId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Menu)
              .WithMany()
              .HasForeignKey(s => s.MenuId)
              .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
