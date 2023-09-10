using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustedCaptain.Handlers
{
    class PlayerHandler
    {

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {

            if (TrustedCaptain.Singleton.Config.TrustedCaptains.IsEmpty()) return;

            if (ev.Reason == SpawnReason.Respawn && ev.NewRole == RoleTypeId.NtfCaptain && !TrustedCaptain.Singleton.Config.TrustedCaptains.Values.Contains(ev.Player.UserId)) ev.NewRole = RoleTypeId.NtfPrivate;
        }

    }
}
