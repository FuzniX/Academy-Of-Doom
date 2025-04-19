using System.Collections.Generic;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof.People
{
    public class StudentsStrike : AbstractPeopleAction
    {
        public const int Amount = 2;

        private const int BotlingHpToRetrieve = 3;

        private const int ProfHpToLose = 1;

        public StudentsStrike(string name, List<ProfRoom> profRooms, List<Botling> botlings) : base(name, profRooms, botlings)
        {
        }

        public override void Execute()
        {
            Botlings.ForEach(botling =>
            {
                ChangeBotlingHp(botling, BotlingHpToRetrieve);
                if (Game.FindRoomAt(botling.X, botling.Y, new List<Room>(ProfRooms)) is ProfRoom profRoom)
                {
                    ChangeProfHp(profRoom, ProfHpToLose);
                }
            });
        }
    }
}
