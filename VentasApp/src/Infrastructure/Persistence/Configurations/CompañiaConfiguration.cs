namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class CompañiaConfiguration : IEntityTypeConfiguration<Compañia>
    {
        public void Configure(EntityTypeBuilder<Compañia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(t => t.Tercero)
               .WithMany()
               .HasForeignKey(s => s.TerceroId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}