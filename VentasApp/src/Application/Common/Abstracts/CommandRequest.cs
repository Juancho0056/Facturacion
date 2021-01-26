using VentasApp.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Application.Common.Abstracts
{
    public abstract class CommandRequest<TData> : IRequest<CommandResult<TData>>
    {
    }
}
