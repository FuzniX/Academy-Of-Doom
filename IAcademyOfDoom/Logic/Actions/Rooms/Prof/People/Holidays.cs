using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof.People
{
    public class Holidays : AbstractPeopleAction
    {

        public Holidays(string name, List<ProfRoom> profRooms, List<Botling> botlings) : base(name, profRooms, botlings)
        {
        }

        public override void Execute()
        {
            ChangeBotlingsHp(2);
            ChangeProfsHp(2);
        }
    }
}
