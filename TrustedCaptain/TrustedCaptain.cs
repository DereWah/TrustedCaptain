using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;
using Map = Exiled.Events.Handlers.Map;


namespace TrustedCaptain
{
    public class TrustedCaptain : Plugin<Config>
    {
        public override string Name => "TrustedCaptain";
        public override string Prefix => "TrustedCaptain";
        public override string Author => "@derewah";
        public override PluginPriority Priority { get; } = PluginPriority.Medium;


        public static TrustedCaptain Instance { get; private set; }


        private Handlers.ServerHandler serverHandler;


        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            serverHandler = new Handlers.ServerHandler(this);

            Server.RespawningTeam += serverHandler.OnRespawningTeam;
        }

        public void UnregisterEvents()
        {
            Server.RespawningTeam -= serverHandler.OnRespawningTeam;

            serverHandler = null;
        }





    }
}
