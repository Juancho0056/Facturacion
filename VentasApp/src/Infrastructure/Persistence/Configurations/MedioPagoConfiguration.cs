namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public partial class MedioPagoConfiguration : IEntityTypeConfiguration<MedioPago>
    {
        public void Configure(EntityTypeBuilder<MedioPago> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(80)")
               .IsRequired();
        }
    }
}
