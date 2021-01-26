using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Infrastructure.Services
{
    public class EmailOptions
    {

        public int Port { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public string Host { get; set; }

    }
}