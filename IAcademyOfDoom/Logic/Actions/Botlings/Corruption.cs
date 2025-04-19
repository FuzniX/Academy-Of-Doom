using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.Logic.Actions.Botlings
{
    public class Corruption : AbstractBotlingsAction
    {
        public const int Amount = 1;
        
        public Corruption(string name, List<Botling> botlings) : base(name, botlings)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}