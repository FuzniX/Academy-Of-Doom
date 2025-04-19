using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof
{
    public class BudgetCuts : AllProfRoomsAction
    {
        public static readonly int Amount = 1;
        
        public BudgetCuts(string name, List<ProfRoom> profRooms) : base(name, profRooms)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
