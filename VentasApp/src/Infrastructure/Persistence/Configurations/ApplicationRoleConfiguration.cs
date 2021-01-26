using Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Infrastructure.Persistence.Configurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.Property(t => t.Name)
              .HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property(t => t.Description)
               .HasColumnType("varchar(60)").HasMaxLength(60);
            builder.Property(t => t.CreadoPor)
               .HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(t => t.ModificadoPor)
                .HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(t => t.Access).IsRequired();
        }
    }
}

