using Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.HasOne(t => t.User)
              .WithMany()
              .HasForeignKey(s => s.UserId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Role)
              .WithMany()
              .HasForeignKey(s => s.RoleId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
