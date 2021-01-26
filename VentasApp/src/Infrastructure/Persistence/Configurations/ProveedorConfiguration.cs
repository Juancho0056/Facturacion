namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.DescuentoComercial)
              .HasColumnType("decimal(28,2)")
              .IsRequired();
            builder.Property(t => t.ReteIcaSN)
               .HasColumnType("char(1)")
               .IsRequired();
            builder.Property(t => t.ReteIvaSN)
               .HasColumnType("char(1)")
               .IsRequired();
            builder.Property(t => t.ReteFteSN)
               .HasColumnType("char(1)")
               .IsRequired();
            builder.Property(t => t.AutoRetenedorSN)
               .HasColumnType("char(1)")
               .IsRequired();
            builder.Property(t => t.DeclaranteSN)
               .HasColumnType("char(1)")
               .IsRequired();
            builder.Property(t => t.Cupo)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.TipoProveedorId)
                .IsRequired();
            builder.HasOne(t => t.TipoProveedor)
               .WithMany()
               .HasForeignKey(s => s.TipoProveedorId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Zona)
               .WithMany()
               .HasForeignKey(s => s.ZonaId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.RepVenta)
               .WithMany()
               .HasForeignKey(s => s.RepresentanteVentaId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Lista)
               .WithMany()
               .HasForeignKey(s => s.ListaPrecioId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ReteFuente)
               .WithMany()
               .HasForeignKey(s => s.ReteFuenteId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ReteFuenteServicios)
               .WithMany()
               .HasForeignKey(s => s.ReteFuenteServiciosId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ReteIcaServicios)
               .WithMany()
               .HasForeignKey(s => s.ReteIcaServiciosId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ReteIca)
              .WithMany()
              .HasForeignKey(s => s.ReteIcaId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
