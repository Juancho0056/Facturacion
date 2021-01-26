namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class RepVentaConfiguration : IEntityTypeConfiguration<RepVenta>
    {
        public void Configure(EntityTypeBuilder<RepVenta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.MetaVenta)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.Comision)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.Notas)
               .HasColumnType("varchar(90)")
               .IsRequired();
            builder.HasOne(t => t.Tercero)
                .WithMany()
                .HasForeignKey(s => s.TerceroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}