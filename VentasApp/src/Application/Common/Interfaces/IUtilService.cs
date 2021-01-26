using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Application.Common.Interfaces
{
    public interface IUtilService
    {
        public bool IsGuid(string guid);
        public bool validateEmail(string email);
        Task<string> getHtmlBodyAccount(string Username, string Password);
    }
}