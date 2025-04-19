using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.Logic.Actions.Botlings
{
    public class DistanceLearning : AllBotlingsAction
    {
        public static readonly int Amount = 1;
        
        private readonly SkillType skill;
        
        public DistanceLearning(string name, List<Botling> botlings, SkillType skill) : base(name, botlings)
        {
            this.skill = skill;
        }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
