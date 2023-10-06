using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MEC;
using PlayerRoles;
using Respawning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustedCaptain.Handlers
{
    public class ServerHandler
    {

        private readonly TrustedCaptain plugin;
        public ServerHandler(TrustedCaptain plugin) => this.plugin = plugin;


        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam != SpawnableTeamType.NineTailedFox) return;

            //A trusted captain is searched for in the spawning list
            Player? player = ev.Players.FirstOrDefault(p => plugin.Config.TrustedCaptains.Values.Contains(p.UserId));
            
            if(player == null)
            {
                //if it is not found it is looked for in the spectators
                player = Player.Get(RoleTypeId.Spectator).FirstOrDefault(p => plugin.Config.TrustedCaptains.Values.Contains(p.UserId));
            }
            else
            {
                //if it is found we remove it from the pool
                ev.Players.Remove(player);
            }

            //if no player was found in spectators either, we go with standard game behaviour
            if(player == null) return;
            //if was found in the spectators or in the pool we remove the captain from spawnable roles and spawn said player as a captain.
            ev.SpawnQueue.RemoveFromQueue(RoleTypeId.NtfCaptain);
            player.Role.Set(RoleTypeId.NtfCaptain, SpawnReason.Respawn);

        }

    }
}
