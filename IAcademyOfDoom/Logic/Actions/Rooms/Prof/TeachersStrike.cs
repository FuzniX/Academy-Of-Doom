using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof
{
    public class TeachersStrike : AbstractProfRoomsAction
    {
        public const int Amount = 2;

        private const int HpToRetrieve = 10;

        public TeachersStrike(string name, List<ProfRoom> profRooms) : base(name, profRooms)
        {
        }

        public override void Execute()
        {
            ChangeProfsHp(HpToRetrieve);
            ProfRooms.ForEach(room => room.LessonNext = false);
        }
    }
}