using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.Logic.Actions.Botlings
{
    public class Corruption : AbstractBotlingsAction
    {
        public const int Amount = 1;

        private const int HpToLose = 3;

        private const int MoneyPerDeath = 1;
        
        private readonly Game game;
        
        public Corruption(string name, List<Botling> botlings, Game game) : base(name, botlings)
        {
            this.game = game;
        }

        public override void Execute()
        {
            Botlings.ForEach(botling =>
            {
                ChangeBotlingHp(botling, HpToLose);
                if (botling.HP <= 0) game.AddMoney(MoneyPerDeath);
            });
        }
    }
}