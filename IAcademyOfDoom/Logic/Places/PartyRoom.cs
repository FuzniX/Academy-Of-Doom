using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.Logic.Places
{
    public class PartyRoom : Room
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">the column</param>
        /// <param name="y">the row</param>
        public PartyRoom(int x, int y) : base(x, y)
        {
            Type = RoomType.Facility;
        }

        public override object ActOnEntry(Botling botling)
        {
            if (botling.HP >= 3)
            {
                int toLose = botling.HP -1;
                botling.HP -= toLose;

                foreach (SkillType skill in SkillTypeUtils.AllBaseSkills())
                {
                    botling.Skills[skill] += toLose;
                }
            }
            return true;
        }
    }
}