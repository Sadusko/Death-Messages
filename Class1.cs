using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned;
using Rocket.Core;
using UnityEngine;
using Rocket.Unturned.Plugins;
using SDG;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using DeathMessages;
using Steamworks;

//Yeha, we are on GitHub
namespace Sadusko.DeathMessages
{
    public class PlayerDeath : RocketPlugin<DMC2>
    {
        public static PlayerDeath Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("Sadusko's Death Messages has been loaded!");
            #region Event
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerUpdateHealth += UnturnedPlayerEvents_OnPlayerUpdateHealth;
            
            #endregion
            Logger.LogError("NOTE:");
            Logger.LogError("Don't forget to set the permission 'deathmessage' in one of the groups.");

            
        }



        private void UnturnedPlayerEvents_OnPlayerDeath(Rocket.Unturned.Player.UnturnedPlayer player, SDG.Unturned.EDeathCause cause, SDG.Unturned.ELimb limb, Steamworks.CSteamID murderer)
        {
            
            if (player.HasPermission("deathmessage"))
            {
                if (cause.ToString() == "ZOMBIE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.zombie + " ", Color.red);
                }
                else if (cause.ToString() == "GUN")
                {
                    UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.gun + " " + player.CharacterName + "!", Color.red);
                }
                else if (cause.ToString() == "MELEE")
                {
                    UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.melee + " " + player.CharacterName + " " + this.Configuration.Instance.melee2, Color.red);
                }
                else if (cause.ToString() == "PUNCH")
                {
                    UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.punch + " " + player.CharacterName + " " + this.Configuration.Instance.punch2, Color.red);
                }
                else if (cause.ToString() == "ROADKILL")
                {
                    UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.roadkill + " " + player.CharacterName + "!", Color.red);
                }
                else if (cause.ToString() == "VEHICLE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.vehicle, Color.red);
                }
                else if (cause.ToString() == "FOOD")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.food, Color.red);
                }
                else if (cause.ToString() == "WATER")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.water, Color.red);
                }
                else if (cause.ToString() == "INFECTION")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.infection, Color.red);
                }
                else if (cause.ToString() == "BLEEDING")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.bleeding, Color.red);
                }
                else if (cause.ToString() == "LANDMINE") 
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.landmine, Color.red);
                }
                else if (cause.ToString() == "BREATH") 
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.breath, Color.red);
                }
                
                else if (cause.ToString() == "SUICIDE" && this.Configuration.Instance.suicidemsg)
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.suicide, Color.red);
                }
                
            }
        }
        protected override void Unload()
        {
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerDeath -= UnturnedPlayerEvents_OnPlayerDeath;
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerUpdateHealth -= UnturnedPlayerEvents_OnPlayerUpdateHealth;
        }

        void UnturnedPlayerEvents_OnPlayerUpdateHealth(Rocket.Unturned.Player.UnturnedPlayer player, byte health)
        {
            if (this.Configuration.Instance.warningmsg)
            {
                if (health == 25)
                {
                    UnturnedChat.Say(player, this.Configuration.Instance.warning1, Color.yellow);
                    UnturnedChat.Say(player, this.Configuration.Instance.warning2, Color.yellow);
                }
            }
           
            
    
        }
    }

}
