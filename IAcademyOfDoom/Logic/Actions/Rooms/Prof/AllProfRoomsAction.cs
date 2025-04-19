using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof
{
    public abstract class AllProfRoomsAction : Action
    {
        protected readonly List<ProfRoom> profRooms;
        
        protected AllProfRoomsAction(string name, List<ProfRoom> profRooms) : base(name)
        {
            this.profRooms = profRooms;
        }
    }
}