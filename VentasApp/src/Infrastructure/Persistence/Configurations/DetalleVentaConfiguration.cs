namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public partial class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id)
               .HasColumnType("varchar(2)")
               .IsRequired();
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(200)")
               .IsRequired();
            builder.Property(t => t.Descuento)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.Cantidad)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.PorcentajeIva)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.ValorUnitario)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.ValorLista)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.PorcentajeRtfte)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrRteIcaC)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrRteIcaS)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrRtfteC)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrRtfteS)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.PorcentajeReteIca)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrRteIcaS)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrRteIcaS)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrDescuento)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VentaBruta)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrIva)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.DescComercial)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.PorImpoConsumo)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.VlrImpoConsumo)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.HasOne(t => t.Venta)
                .WithMany()
                .HasForeignKey(s => s.VentaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Articulo)
                .WithMany()
                .HasForeignKey(s => s.ArticuloId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.UnidadMedida)
               .WithMany()
               .HasForeignKey(s => s.UnidadId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Iva)
               .WithMany()
               .HasForeignKey(s => s.IvaId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ListaPrecio)
              .WithMany()
              .HasForeignKey(s => s.ListaPrecioId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ReteFuente)
              .WithMany()
              .HasForeignKey(s => s.ReteFuenteId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ImpoConsumo)
             .WithMany()
             .HasForeignKey(s => s.ImpoConsumoId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
