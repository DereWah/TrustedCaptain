using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustedCaptain
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public Dictionary<int, string> TrustedCaptains { get; set;  } = new()
        {
            { 1, "userid@steam" },
            { 2, "userid@steam"}
        };
    }
}
