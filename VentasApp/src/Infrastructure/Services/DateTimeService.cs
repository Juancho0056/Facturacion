using VentasApp.Application.Common.Interfaces;
using System;

namespace VentasApp.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
