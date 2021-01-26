namespace Domain.Entities
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class UnidadMedidaConfiguration : IEntityTypeConfiguration<UnidadMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadMedida> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(80)")
               .IsRequired();
        }
    }
}

