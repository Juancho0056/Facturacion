namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class ListaConfiguration : IEntityTypeConfiguration<Lista>
    {
        public void Configure(EntityTypeBuilder<Lista> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(80)")
               .IsRequired();
            builder.Property(t => t.ModificarPrecioSN)
               .HasColumnType("char(1)")
               .IsRequired();
        }
    }
}
