using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Ui
{
    public interface IApplicationConfiguration
    {
        string ApiUrl { get; }
    }
}
