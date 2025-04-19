using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.Logic.Actions.Botlings
{
    public class RefresherCourse : AbstractBotlingsAction
    {
        public const int Amount = 2;
        
        private readonly int x;
        private readonly int y;

        private const int SkillPointsToAdd = 1;

        public RefresherCourse(string name, List<Botling> botlings, int x, int y) : base(name, botlings)
        {
            this.x = x;
            this.y = y;
        }
        
        public override void Execute()
        {
            Botlings.ForEach(botling =>
            {
                if (botling.X == x && botling.Y == y)
                {
                    foreach (SkillType skill in botling.Skills.Keys)
                    {
                        botling.Skills[skill] += SkillPointsToAdd;
                    }
                }
            });
        }
    }
}
