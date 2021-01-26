
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Application;
using VentasApp.Domain.Entities.Application;

namespace VentasApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IBaseDbContext
    {
        DbSet<ApplicationPermission> permissions { get; set; }
        DbSet<ConsultaDatagrid> consultas { get; set; }
        DbSet<ApplicationMenu> menus { get; set; }
        DbSet<ApplicationMenuRole> menusroles { get; set; }
        DbSet<ApplicationPagina> paginas { get; set; }
        DbSet<ApplicationRole> applicationroles { get; set; }
        DbSet<ApplicationUserRole> applicationuserroles { get; set; }
        DbSet<ApplicationUser> applicationusers { get; set; }
        DbSet<Articulo> articulos { get; set; }
        DbSet<Caja> cajas { get; set; }
        DbSet<Ciudad> ciudades { get; set; }
        DbSet<Clase> clases { get; set; }
        DbSet<Cliente> clientes { get; set; }
        DbSet<Compañia> compañias { get; set; }
        DbSet<Consecutivo> consecutivos { get; set; }
        DbSet<Contable> contables { get; set; }
        DbSet<Departamento> departamentos { get; set; }
        DbSet<DetalleVenta> detallesventas { get; set; }
        DbSet<DocumentoIdentificacion> documentosidentificacion { get; set; }
        DbSet<FormaPago> formapagos { get; set; }
        DbSet<Grupo> grupos { get; set; }
        DbSet<ImpoConsumo> impoconsumos { get; set; }
        DbSet<Iva> ivas { get; set; }
        DbSet<ListaPrecio> listaprecios { get; set; }
        DbSet<Lista> listas { get; set; }
        DbSet<Marca> marcas { get; set; }
        DbSet<MedioPago> mediospagos { get; set; }
        DbSet<Pais> paises { get; set; }
        DbSet<Proveedor> proveedores { get; set; }
        DbSet<Regimen> regimenes { get; set; }
        DbSet<RepVenta> repventas { get; set; }
        DbSet<ReteFuente> retefuentes { get; set; }
        DbSet<ReteIca> reteicas { get; set; }
        DbSet<Tercero> tercero { get; set; }
        DbSet<TipoComprador> tipocompradores { get; set; }
        DbSet<TipoDocumento> tiposdocumentos { get; set; }
        DbSet<TipoPersona> tipospersonas { get; set; }
        DbSet<UnidadMedida> unidadesmedidas { get; set; }
        DbSet<Venta> ventas { get; set; }
        DbSet<Zona> zonas { get; set; }

    }
}
