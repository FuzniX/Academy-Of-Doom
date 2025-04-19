using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.Logic.Actions.Botlings
{
    public abstract class AllBotlingsAction : Action
    {
        protected readonly List<Botling> botlings;
        
        protected AllBotlingsAction(string name, List<Botling> botlings) : base(name)
        {
            this.botlings = botlings;
        }
    }
}