using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Application.Common.Interfaces
{
    public interface IReadOnlyRepository
    {

        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class; //, IEntity
        IEnumerable<dynamic> Query(string qry);
    }
}