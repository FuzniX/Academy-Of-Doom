using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.People
{
    public class Holidays : AllPeopleAction
    {
        public static readonly int Amount = 2;
        
        public Holidays(string name, List<ProfRoom> profRooms, List<Botling> botlings) : base(name, profRooms, botlings)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
