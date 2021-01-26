using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace VentasApp.Application.Common.Models
{
    public static class QuerySortingExtension
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IEnumerable<string> sort) where T : class
        {
            if (sort != null)
            {
                List<string> sortFields = new List<string>();

                foreach (string sortField in sort)
                {
                    if (sortField.StartsWith("+"))
                    {
                        sortFields.Add(string.Format("{0} ASC", sortField.TrimStart('+')));
                    }
                    else if (sortField.StartsWith("-"))
                    {
                        sortFields.Add(string.Format("{0} DESC", sortField.TrimStart('-')));
                    }
                    else
                    {
                        sortFields.Add(sortField);
                    }
                }
                return query.OrderBy<T>(string.Join(",", sortFields));
            }

            return query;
        }
    }
}