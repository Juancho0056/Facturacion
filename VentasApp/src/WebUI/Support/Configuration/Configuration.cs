using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentasApp.WebUI.Support.Configuration
{
    public static class Configuration
    {
        public const string ApplicationName = "VentasApp";

        public const string ApplicationNameConnection = "ApiConnection";


        public static class SwaggerConfiguration
        {
            /// <summary>
            /// Swagger Version.
            /// </summary>
            public const string Version1 = "v1";
            /// <summary>
            /// Swagger TermsOfService.
            /// </summary>
            public const string Title = "Documentacion API";
            /// <summary>
            /// Swagger Description.
            /// </summary>
            public const string Description = "Api VentasApp ";
            /// <summary>
            /// Swagger TermsOfService.
            /// </summary>
            public const string TermsOfService = "https://www.ventasapp.com.co";

            /// <summary>
            /// Swagger ContactName.
            /// </summary>
            public const string ContactName = "Administrador";

            /// <summary>
            /// Swagger ContactEmail.
            /// </summary>
            public const string ContactEmail = "main.coldev@coldev.co";

            /// <summary>
            /// Swagger ContactUrl.
            /// </summary>
            public const string ContactUrl = "https://www.ventasapp.com.co";

        }
    }
}
