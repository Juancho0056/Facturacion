using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VentasApp.Domain.Entities.Application;

namespace VentasApp.Infrastructure.Persistence.Configurations
{
    public class ApplicationMenuConfiguration : IEntityTypeConfiguration<ApplicationMenu>
    {
        public void Configure(EntityTypeBuilder<ApplicationMenu> builder)
        {
            builder.Property(t => t.Id)
                .IsRequired();
            builder.Property(t => t.Titulo)
                .HasColumnType("varchar(70)")
                .HasMaxLength(70);
            builder.Property(t => t.Nombre)
                .HasColumnType("varchar(40)")
                .HasMaxLength(40);
            builder.Property(t => t.Url)
                .HasColumnType("varchar(70)")
                .HasMaxLength(70);
            builder.HasOne(t => t.Pagina)
                   .WithMany()
                   .HasForeignKey(s => s.PaginaId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
