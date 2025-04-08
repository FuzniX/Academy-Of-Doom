using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.Logic.Places
{
    public class FacultyLounge : Room
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">the column</param>
        /// <param name="y">the row</param>
        public FacultyLounge(int x, int y) : base(x, y)
        {
            Type = RoomType.Facility;
        }

        public override object ActOnEntry(Botling botling)
        {
            botling.HP -= 3;
            return true;
        }
    }
}