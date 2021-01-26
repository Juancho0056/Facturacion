namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id)
               .HasColumnType("varchar(5)")
               .IsRequired();
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(80)")
               .IsRequired();
            builder.HasOne(t => t.Departamento)
                .WithMany()
                .HasForeignKey(s => s.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
