namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class TerceroConfiguration : IEntityTypeConfiguration<Tercero>
    {
        public void Configure(EntityTypeBuilder<Tercero> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.NroDocumento)
               .HasColumnType("varchar(45)")
               .IsRequired();
            builder.Property(t => t.DigitoVerificacion)
               .HasColumnType("char(2)")
               .IsRequired();
            builder.Property(t => t.PrimerNombre)
               .HasColumnType("varchar(60)")
               .IsRequired();
            builder.Property(t => t.SegundoNombre)
               .HasColumnType("varchar(60)");
            builder.Property(t => t.PrimerApellido)
               .HasColumnType("varchar(60)")
               .IsRequired();
            builder.Property(t => t.SegundoApellido)
               .HasColumnType("varchar(60)");
            builder.Property(t => t.RazonSocial)
               .HasColumnType("varchar(200)");
            builder.Property(t => t.NombreComercial)
               .HasColumnType("varchar(200)");
            builder.Property(t => t.Direccion)
               .HasColumnType("varchar(200)");
            builder.Property(t => t.Email)
               .HasColumnType("varchar(200)");
            builder.Property(t => t.Celular)
               .HasColumnType("varchar(25)");
            builder.Property(t => t.Telefono)
               .HasColumnType("varchar(25)");
            builder.HasOne(t => t.DocumentoIdentificacion)
             .WithMany()
             .HasForeignKey(s => s.DocumentoId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Regimen)
             .WithMany()
             .HasForeignKey(s => s.RegimenId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.TipoPersona)
             .WithMany()
             .HasForeignKey(s => s.TipoPersonaId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Ciudad)
             .WithMany()
             .HasForeignKey(s => s.CiudadUbicacion)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
