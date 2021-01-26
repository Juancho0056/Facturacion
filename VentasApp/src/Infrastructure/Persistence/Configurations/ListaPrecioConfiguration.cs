using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public partial class ListaPrecioConfiguration : IEntityTypeConfiguration<ListaPrecio>
    {
        public void Configure(EntityTypeBuilder<ListaPrecio> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Precio)
               .HasColumnType("decimal(28, 2)")
               .IsRequired();
            builder.HasOne(t => t.Lista)
                .WithMany()
                .HasForeignKey(s => s.ListaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Articulo)
                .WithMany()
                .HasForeignKey(s => s.ArticuloId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.UnidadMedida)
                .WithMany()
                .HasForeignKey(s => s.UnidadMedidaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
