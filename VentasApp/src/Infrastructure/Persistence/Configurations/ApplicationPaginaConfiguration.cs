using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VentasApp.Domain.Entities.Application;

namespace VentasApp.Infrastructure.Persistence.Configurations
{
    public class ApplicationPaginaConfiguration : IEntityTypeConfiguration<ApplicationPagina>
    {
        public void Configure(EntityTypeBuilder<ApplicationPagina> builder)
        {
            
            builder.Property(p => p.Nombre)
                .HasColumnType("varchar(40)")
                .IsRequired();
            builder.Property(p => p.Url)
                .HasColumnType("varchar(200)")
                .IsRequired();
            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(70)")
                .IsRequired();
            builder.Property(p => p.Proyecto)
                .HasColumnType("varchar(70)")
                .IsRequired();
        }
    }
}
