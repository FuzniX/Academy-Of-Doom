using System.Collections.Generic;
using IAcademyOfDoom.Logic.GameSettings;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof
{
    public abstract class AbstractProfRoomsAction : Action
    {
        protected readonly List<ProfRoom> ProfRooms;
        
        protected AbstractProfRoomsAction(string name, List<ProfRoom> profRooms) : base(name)
        {
            ProfRooms = profRooms;
        }

        protected void ChangeProfsHp(int amount)
        {
            ProfRooms.ForEach(room => ChangeProfHp(room, amount));
        }
        
        protected void ChangeProfHp(ProfRoom profRoom, int amount)
        {
            profRoom.HP = profRoom.HP < Default.BaseProfHitPoints - amount
                ? profRoom.HP + amount
                : Default.BaseProfHitPoints;
        }
    }
}