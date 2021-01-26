using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Application.Common.Interfaces
{
    public interface IEmailSender
    {
        Task<int> SendEmailAsync(string email, string name, string subject, string body);
    }
}
