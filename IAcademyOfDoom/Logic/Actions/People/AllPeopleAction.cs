using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.People
{
    public abstract class AllPeopleAction : Action
    {
        protected readonly List<ProfRoom> profRooms;

        protected readonly List<Botling> botlings;
        
        protected AllPeopleAction(string name, List<ProfRoom> profRooms, List<Botling> botlings) : base(name)
        {
            this.profRooms = profRooms;
            this.botlings = botlings;
        }
    }
}