using System.Collections.Generic;
using IAcademyOfDoom.Logic.GameSettings;
using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.Logic.Actions.Botlings
{
    public abstract class AbstractBotlingsAction : Action
    {
        protected readonly List<Botling> Botlings;
        
        protected AbstractBotlingsAction(string name, List<Botling> botlings) : base(name)
        {
            Botlings = botlings;
        }

        public static void ChangeBotlingsHp(List<Botling> botlings, int amount)
        {
            botlings.ForEach(botling => ChangeBotlingHp(botling, amount));
        }

        public static void ChangeBotlingHp(Botling botling, int amount)
        {
            botling.HP = botling.HP < Default.BaseHitPoints(Game.Difficulty) - amount
                ? botling.HP + amount
                : Default.BaseHitPoints(Game.Difficulty);
        }
    }
}