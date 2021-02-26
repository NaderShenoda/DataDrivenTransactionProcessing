using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionAdministrationPortal
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string ApiUrl { get; set; } = "https://localhost:44312/api";
    }
}
