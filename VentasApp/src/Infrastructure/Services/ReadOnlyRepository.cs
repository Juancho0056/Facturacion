using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Application.Common.Interfaces;

namespace VentasApp.Infrastructure.Services
{
    public class EntityFrameworkReadOnlyRepository<TContext> : IReadOnlyRepository
          where TContext : DbContext
    {
        protected readonly TContext _context;

        public EntityFrameworkReadOnlyRepository(TContext context)
        {
            _context = context;
        }

        private dynamic SqlDataReaderToExpando(DbDataReader reader)
        {
            var expandoObject = new ExpandoObject() as IDictionary<string, object>;

            for (var i = 0; i < reader.FieldCount; i++)
            {
                expandoObject.Add(reader.GetName(i), reader[i]);
                var prueba = reader.GetName(i);
            }



            return expandoObject;
        }

        public virtual IEnumerable<dynamic> Query(string qry)
        //, IEntity
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = qry;
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    //dynamic data = new ExpandoObject();

                    while (result.Read())
                    {
                        yield return SqlDataReaderToExpando(result);
                    }
                }
            }
        }

        public Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
