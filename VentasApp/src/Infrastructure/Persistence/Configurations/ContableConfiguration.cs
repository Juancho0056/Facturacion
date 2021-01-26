namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class ContableConfiguration : IEntityTypeConfiguration<Contable>
    {
        public void Configure(EntityTypeBuilder<Contable> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(80)")
               .IsRequired();
            builder.HasOne(t => t.IvaVenta)
                .WithMany()
                .HasForeignKey(s => s.IvaVentaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.IvaCompra)
                .WithMany()
                .HasForeignKey(s => s.IvaCompraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ImpoConsumo)
                .WithMany()
                .HasForeignKey(s => s.ImpoConsumoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
