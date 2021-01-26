using Domain.Entities;
using VentasApp.Application.Common.Interfaces;
using Domain.Entities.Application;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Domain.Common;
using VentasApp.Domain.Entities.Application;

namespace VentasApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private IDbContextTransaction _currentTransaction;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<ConsultaDatagrid> consultas { get; set; }
        public DbSet<ApplicationPermission> permissions { get; set; }
        public DbSet<ApplicationMenu> menus { get; set; }
        public DbSet<ApplicationMenuRole> menusroles { get; set; }
        public DbSet<ApplicationPagina> paginas { get; set; }
        public DbSet<ApplicationRole> applicationroles { get; set; }
        public DbSet<ApplicationUserRole> applicationuserroles { get; set; }
        public DbSet<ApplicationUser> applicationusers { get; set; }
        public DbSet<Articulo> articulos { get; set; }
        public DbSet<Caja> cajas { get; set; }
        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Clase> clases { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Compañia> compañias { get; set; }
        public DbSet<Consecutivo> consecutivos { get; set; }
        public DbSet<Contable> contables { get; set; }
        public DbSet<Departamento> departamentos { get; set; }
        public DbSet<DetalleVenta> detallesventas { get; set; }
        public DbSet<DocumentoIdentificacion> documentosidentificacion { get; set; }
        public DbSet<FormaPago> formapagos { get; set; }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<ImpoConsumo> impoconsumos { get; set; }
        public DbSet<Iva> ivas { get; set; }
        public DbSet<ListaPrecio> listaprecios { get; set; }
        public DbSet<Lista> listas { get; set; }
        public DbSet<Marca> marcas { get; set; }
        public DbSet<MedioPago> mediospagos { get; set; }
        public DbSet<Pais> paises { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Regimen> regimenes { get; set; }
        public DbSet<RepVenta> repventas { get; set; }
        public DbSet<ReteFuente> retefuentes { get; set; }
        public DbSet<ReteIca> reteicas { get; set; }
        public DbSet<Tercero> tercero { get; set; }
        public DbSet<TipoComprador> tipocompradores { get; set; }
        public DbSet<TipoProveedor> tipoproveedores { get; set; }
        public DbSet<TipoDocumento> tiposdocumentos { get; set; }
        public DbSet<TipoPersona> tipospersonas { get; set; }
        public DbSet<UnidadMedida> unidadesmedidas { get; set; }
        public DbSet<Venta> ventas { get; set; }
        public DbSet<Zona> zonas { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreadoPor = _currentUserService.UserId;
                        entry.Entity.FechaCreacion = _dateTime.Now;
                        entry.Entity.EstadoRegistro = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModificadoPor = _currentUserService.UserId;
                        entry.Entity.FechaModificacion = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public void DetachAll()
        {
            foreach (EntityEntry dbEntityEntry in this.ChangeTracker.Entries().ToArray())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }

    }
}
