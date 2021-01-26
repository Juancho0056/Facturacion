namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id)
               .HasColumnType("varchar(2)")
               .IsRequired();
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(80)")
               .HasMaxLength(80)
               .IsRequired();
            builder.HasOne(t => t.Pais)
                .WithMany()
                .HasForeignKey(s => s.PaisId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

