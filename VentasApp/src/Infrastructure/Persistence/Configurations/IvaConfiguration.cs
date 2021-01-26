namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class IvaConfiguration : IEntityTypeConfiguration<Iva>
    {
        public void Configure(EntityTypeBuilder<Iva> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(80)")
               .IsRequired();
            builder.Property(t => t.Valor)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
        }
    }
}
