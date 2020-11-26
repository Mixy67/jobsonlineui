using Rocket.API.Serialisation;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JobsOnlineUI
{
    public class Main : RocketPlugin<Config>
    {
        protected override void Load()
        {
            StartCoroutine((IEnumerator)Count());
        }
        protected override void Unload()
        {
            StartCoroutine((IEnumerator)Count());
        }
        private IEnumerator<WaitForSeconds> Count()
        {
            while (true)
            {
                UpdateUI(); 
                yield return new WaitForSeconds((float)2);
            }
        }
        public void UpdateUI()
        {
            int police = 0, doctor = 0, taxi = 0;

            var c = Configuration.Instance;

            foreach (SteamPlayer steamPlayer in Provider.clients)
            {
                UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromSteamPlayer(steamPlayer);
                var groups = R.Permissions.GetGroups(unturnedPlayer, true);
                foreach (RocketPermissionsGroup playergroup in groups)
                {
                    if (playergroup.Id == c.PoliceID) police += 1;
                    else if (playergroup.Id == c.DoctorID) doctor += 1;
                    else if (playergroup.Id == c.TaxiID) taxi += 1;
                }
            }
            foreach (SteamPlayer player in Provider.clients)
            {
                EffectManager.sendUIEffect(c.EffectID, 132, player.playerID.steamID, true, $"<color={c.PoliceCountColor}>" + police.ToString() + "</color>", $"<color={c.DoctorCountColor}>" + doctor.ToString() + "</color>", $"<color={c.TaxiCountColor}>" +  taxi.ToString() + "</color>");
            }
        }
    }
}
