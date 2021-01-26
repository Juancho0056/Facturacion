using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Application
{
    public class EnumerableRequest
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
        public string[] sort { get; set; }
    }
}
