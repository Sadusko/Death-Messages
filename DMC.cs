using Rocket.API;

namespace DeathMessages
{
    public class DMC2 : IRocketPluginConfiguration
    {
        public bool suicidemsg;
        public bool warningmsg;
        public string warning1;
        public string warning2;
        public string zombie;
        public string gun;
        public string melee;
        public string melee2;
        public string punch;
        public string punch2;
        public string roadkill;
        public string vehicle;
        public string food;
        public string water;
        public string infection;
        public string bleeding;
        public string suicide;
        public string landmine;
        public string breath;

        public void LoadDefaults()
        {

                    suicidemsg = true;
                    warningmsg = true;
                    warning1 = "WARNING: You are about to die!";
                    warning2 = "We recommend you to patch yourself up!";
                    zombie = "has been mauled by a zombie!";
                    gun = "shot and killed";
                    melee = "has melee'd";
                    melee2 = "to death!";
                    punch = "has punched";
                    punch2 = "to death!";
                    roadkill = "ran over";
                    vehicle = "has died due to an explosion of a vehicle!";
                    food = "has starved to death!";
                    water = "has dehydrated to death!";
                    infection = "has become a zombie himself!";
                    bleeding = "has bled to death!";
                    suicide = "has killed himself!";
                    landmine = "has been blown up by a landmine!";
                    breath = "died of holding his breath for too long!";

        }
    }
}
