namespace Domain.Entities
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.NroFactura)
               .HasColumnType("varchar(45)");
            builder.Property(t => t.TotalBruto)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.DsctoProd)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.DsctoComer)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.BaseIva)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.ValorIva)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.ValorVenta)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TotalRetefuenteC)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TotalRetefuenteS)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TotalReteIcaC)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TotalReteIcaS)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TotalReteIva)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TotalOtrRetencion)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TotalAutoRetencion)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TotalPagar)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.ValorImpConsumo)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.Resolucion)
               .HasColumnType("varchar(200)");
            builder.Property(t => t.NroFactura)
               .HasColumnType("varchar(45)");
            builder.HasOne(t => t.TipoDocumento)
              .WithMany()
              .HasForeignKey(s => s.TipoDocumentoId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Cliente)
              .WithMany()
              .HasForeignKey(s => s.ClienteId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Ciudad)
              .WithMany()
              .HasForeignKey(s => s.MunicipioId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.RepVenta)
              .WithMany()
              .HasForeignKey(s => s.RepVentaId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Caja)
              .WithMany()
              .HasForeignKey(s => s.CajaId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

