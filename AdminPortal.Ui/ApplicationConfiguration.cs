using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Ui
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string ApiUrl { get; set; } = "http://localhost:13938/api";
    }
}
