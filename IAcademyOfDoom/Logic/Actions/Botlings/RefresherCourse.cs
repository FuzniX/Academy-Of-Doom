using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.Logic.Actions.Botlings
{
    public class RefresherCourse : AllBotlingsAction
    {
        public static readonly int Amount = 2;
        
        private int x;
        private int y;
        public RefresherCourse(string name, List<Botling> botlings, int x, int y) : base(name, botlings)
        {
            this.x = x;
            this.y = y;
        }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
