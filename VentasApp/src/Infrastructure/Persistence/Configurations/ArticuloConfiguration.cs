namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Detalle)
                .HasColumnType("varchar(80)");
            builder.Property(t => t.Descripcion)
                .HasColumnType("varchar(250)");
            builder.Property(t => t.Factor)
                .HasColumnType("decimal(28, 2)");
            builder.Property(t => t.Modelo)
                .HasColumnType("varchar(45)");
            builder.Property(t => t.Referencia)
                .HasColumnType("varchar(250)");
            builder.Property(t => t.Imagen)
                .HasColumnType("varchar(250)");
            builder.Property(t => t.Observacion)
                .HasColumnType("varchar(250)");
            builder.Property(t => t.TipoCatalogo)
                .HasColumnType("char(1)");
            builder.Property(t => t.ClaseId).IsRequired();
            builder.HasOne(t => t.Clase)
               .WithMany()
               .HasForeignKey(s => s.ClaseId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.ContableId).IsRequired();
            builder.HasOne(t => t.Contable)
               .WithMany()
               .HasForeignKey(s => s.ContableId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.GrupoId).IsRequired();
            builder.HasOne(t => t.Grupo)
               .WithMany()
               .HasForeignKey(s => s.GrupoId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.MarcaId).IsRequired();
            builder.HasOne(t => t.Marca)
               .WithMany()
               .HasForeignKey(s => s.MarcaId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.UnidadMedidaId).IsRequired();
            builder.HasOne(t => t.UnidadMedida)
               .WithMany()
               .HasForeignKey(s => s.UnidadMedidaId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
