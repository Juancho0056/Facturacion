namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class ConsecutivoConfiguration : IEntityTypeConfiguration<Consecutivo>
    {
        public void Configure(EntityTypeBuilder<Consecutivo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.NroResolucion)
               .HasColumnType("varchar(250)")
               .IsRequired();
            builder.Property(t => t.Detalle)
              .HasColumnType("varchar(80)")
              .IsRequired();
            builder.Property(t => t.Prefijo)
             .HasColumnType("varchar(45)");
            builder.Property(t => t.Descripcion)
             .HasColumnType("varchar(250)");
        }
    }
}
