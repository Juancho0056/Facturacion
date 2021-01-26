namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public partial class ReteFuenteConfiguration : IEntityTypeConfiguration<ReteFuente>
    {
        public void Configure(EntityTypeBuilder<ReteFuente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(100)")
               .IsRequired();
            builder.Property(t => t.Porcentaje)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.Property(t => t.CuentaV)
               .HasColumnType("varchar(45)")
               .IsRequired();
            builder.Property(t => t.CuentaDV)
               .HasColumnType("varchar(45)")
               .IsRequired();
            builder.Property(t => t.TipoCatalogo)
                .HasColumnType("char(1)");
            builder.Property(t => t.CuentaC)
               .HasColumnType("varchar(45)")
               .IsRequired();
            builder.Property(t => t.CuentaDC)
               .HasColumnType("varchar(45)")
               .IsRequired();
            builder.Property(t => t.DeclaranteSN)
               .HasColumnType("varchar(1)")
               .IsRequired();
            builder.Property(t => t.Tope)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            
        }
    }
}