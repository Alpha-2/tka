using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace tka
{
    public class Config : IConfig
    {
        [Description("Enable plugin")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
    }
}
