using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof
{
    public class FigureVisit : AbstractProfRoomsAction
    {

        private const int HpToRetrieve = 5;

        public FigureVisit(string name, List<ProfRoom> profRooms) : base(name, profRooms)
        {
        }

        public override void Execute()
        {
            ChangeProfsHp(HpToRetrieve);
        }
    }
}
