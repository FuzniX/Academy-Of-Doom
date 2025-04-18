using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.Logic.Mobiles
{
    public class Lucky : Botling
    {
        public Lucky() : base(BotType.Lucky)
        {
            HP -= 2;
        }

        public override bool TestSkill(SkillType skill, int difficulty, int diceRoll)
        {
            // What does (mais le 1 est tout de même ajouté) mean?
            // Does it mean that we should add 1 from previous dice roll to the new one?
            // From what we've understood, we've added 1 to the new dice roll.
            while (diceRoll == 1) diceRoll = DiceRoll() + 1; 
            return base.TestSkill(skill, difficulty, diceRoll);
        }
    }
}