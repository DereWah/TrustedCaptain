using Exiled.API.Enums;
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
    class ServerHandler
    {

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            Log.Info("Respawning Team!");
            if (ev.NextKnownTeam != SpawnableTeamType.NineTailedFox) return;

            Timing.CallDelayed(3f, () => {

                if (ev.Players.Where(p => p.Role.Type == RoleTypeId.NtfCaptain).Count() != 0) return;

                foreach (Player player in ev.Players.Where(p => TrustedCaptain.Singleton.Config.TrustedCaptains.Values.Contains(p.UserId)))
                {
                    player.Role.Set(RoleTypeId.NtfCaptain, reason: SpawnReason.Respawn);
                    return;
                }
                //If still no captain, searchs for a trusted one in the Spectators.
                foreach(Player player in Player.List.Where(p => (p.Role.Type == RoleTypeId.Spectator && TrustedCaptain.Singleton.Config.TrustedCaptains.Values.Contains(p.UserId))))
                {
                    player.Role.Set(RoleTypeId.NtfCaptain, reason: SpawnReason.Respawn);
                    return;
                }

                //If still nothing, get a random cadet.
                ev.Players.RandomItem().Role.Set(RoleTypeId.NtfCaptain);
                return;
                

            });
        }

    }
}
