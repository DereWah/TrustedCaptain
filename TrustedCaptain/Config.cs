using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustedCaptain
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("A list of players that will be trusted to spawn as captains. Key of the dictionary values below can be anything")]
        public Dictionary<string, string> TrustedCaptains { get; set;  } = new()
        {
            { "APlayerHere", "userid@steam" },
            { "AnotherPlayerWoah", "userid@steam"}
        };
    }
}
