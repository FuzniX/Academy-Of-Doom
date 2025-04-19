using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof
{
    public class FigureVisit : AllProfRoomsAction
    {
        public static readonly int Amount = 3;
        
        public FigureVisit(string name, List<ProfRoom> profRooms) : base(name, profRooms)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
