using IAcademyOfDoom.Logic.GameSettings;
using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.Logic.Places
{
    public class RestRoom : Room
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">the column</param>
        /// <param name="y">the row</param>
        public RestRoom(int x, int y) : base(x, y)
        {
            
        }

        public override object ActOnEntry(Botling botling)
        {
            int lostHP = Default.BaseHitPoints(Game.Difficulty) - botling.HP;
            if (lostHP > 0)
            {
                botling.HP += lostHP/2;
            }

            return (lostHP > 0);
        }
    }
}