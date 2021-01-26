using Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //    builder.Property(t => t.Id)
            //        .HasColumnType("varchar(60)")
            //        .HasMaxLength(60);
            builder.Property(t => t.UserName)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
            builder.Property(t => t.NormalizedUserName)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
            builder.Property(t => t.Email)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
            builder.Property(t => t.NormalizedEmail)
                .HasColumnType("varchar(60)")
                .HasMaxLength(60);
            builder.Property(t => t.PhoneNumber)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);
            builder.Property(t => t.IdentificationCard)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);
            builder.Property(t => t.FirstName)
                .HasColumnType("varchar(80)")
                .HasMaxLength(80);
            builder.Property(t => t.LastName)
                .HasColumnType("varchar(80)")
                .HasMaxLength(80);
            builder.Property(t => t.CreadoPor)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
            builder.Property(t => t.ModificadoPor)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
        }
    }
}

