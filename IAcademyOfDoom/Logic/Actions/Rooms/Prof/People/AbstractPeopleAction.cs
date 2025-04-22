using System.Collections.Generic;
using IAcademyOfDoom.Logic.Actions.Botlings;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof.People
{
    public abstract class AbstractPeopleAction : AbstractProfRoomsAction
    {
        protected readonly List<Botling> Botlings;
        
        protected AbstractPeopleAction(string name, List<ProfRoom> profRooms, List<Botling> botlings) : base(name, profRooms)
        {
            Botlings = botlings;
        }
        
        protected void ChangeBotlingsHp(int amount)
        {
            Botlings.ForEach(botling => ChangeBotlingHp(botling, amount));
        }

        protected void ChangeBotlingHp(Botling botling, int amount)
        {
            AbstractBotlingsAction.ChangeBotlingHp(botling, amount);
        }
    }
}