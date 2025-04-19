using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.Logic.Actions.Botlings
{
    public class DistanceLearning : AbstractBotlingsAction
    {
        public const int Amount = 1;
        
        private readonly SkillType skill;

        private const int HpToLose = 1;
        
        public DistanceLearning(string name, List<Botling> botlings, SkillType skill) : base(name, botlings)
        {
            this.skill = skill;
        }
        
        public override void Execute()
        {
            Botlings.ForEach(botling =>
            {
                ChangeBotlingHp(botling, -HpToLose);
                botling.GetLessonIn(skill);
            });
        }
    }
}
