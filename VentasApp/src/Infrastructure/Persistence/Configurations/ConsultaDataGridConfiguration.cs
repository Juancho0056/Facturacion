namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;
    using VentasApp.Domain.Entities.Application;

    public partial class ConsultaDatagridConfiguration : IEntityTypeConfiguration<ConsultaDatagrid>
    {
        public void Configure(EntityTypeBuilder<ConsultaDatagrid> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Tipo)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(t => t.Pagina)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(t => t.SentenciaTable)
               .HasColumnType("nvarchar(3000)")
               .IsRequired();

            builder.Property(t => t.SentenciaCount)
               .HasColumnType("nvarchar(3000)")
               .IsRequired();
        }
    }
}
