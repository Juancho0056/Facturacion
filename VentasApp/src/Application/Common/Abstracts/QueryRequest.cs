using VentasApp.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Application.Common.Abstracts
{
    public abstract class QueryRequest<TData> : EnumerableRequest, IRequest<QueryResult<TData>>
    {
    }
}
