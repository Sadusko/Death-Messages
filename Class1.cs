using Rocket.API;
using UnityEngine;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using SDG.Unturned;

//Yeha, we are on GitHub
namespace Sadusko.DeathMessages
{
    public class PlayerDeath : RocketPlugin<DMCconf>
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

            Logger.LogError(this.Configuration.Instance.suicidemsg ? "Suicide messages are enabled!" : "Suicide messages are disabled!");

            if (this.Configuration.Instance.warningmsg)
            {
                Logger.LogError("Health warning messages are enabled!");
            }
        }

        private void UnturnedPlayerEvents_OnPlayerDeath(Rocket.Unturned.Player.UnturnedPlayer player, SDG.Unturned.EDeathCause cause, SDG.Unturned.ELimb limb, Steamworks.CSteamID murderer)
        {
            if (player.HasPermission("deathmessage"))
            {
                switch (cause)
                {
                    case EDeathCause.BLEEDING:
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.bleeding, Color.red);
                        break;
                    case EDeathCause.FOOD:
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.food, Color.red);
                        break;
                    case EDeathCause.WATER:
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.water, Color.red);
                        break;
                    case EDeathCause.GUN:
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.gun + " " + player.CharacterName + "!", Color.red);
                        break;
                    case EDeathCause.MELEE:
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.melee + " " + player.CharacterName + " " + this.Configuration.Instance.melee2, Color.red);
                        break;
                    case EDeathCause.ZOMBIE:
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.zombie + " ", Color.red);
                        break;
                    case EDeathCause.SUICIDE:
                        if (this.Configuration.Instance.suicidemsg)
                            UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.suicide, Color.red);
                        break;
                    case EDeathCause.INFECTION:
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.infection, Color.red);
                        break;
                    case EDeathCause.PUNCH:
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.punch + " " + player.CharacterName + " " + this.Configuration.Instance.punch2, Color.red);
                        break;
                    case EDeathCause.ROADKILL:
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.roadkill + " " + player.CharacterName + "!", Color.red);
                        break;
                    case EDeathCause.VEHICLE:
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.vehicle, Color.red);
                        break;
                }
            }
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
