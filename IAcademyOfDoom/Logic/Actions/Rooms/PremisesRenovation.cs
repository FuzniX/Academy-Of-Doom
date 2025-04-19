using IAcademyOfDoom.Logic.GameSettings;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms
{
    public class PremisesRenovation : Action
    {
        private readonly ProfRoom profRoom;
        
        public PremisesRenovation(string name, ProfRoom profRoom) : base(name)
        {
            this.profRoom = profRoom;
        }
        
        public override void Execute()
        {
            profRoom.HP = Default.BaseProfHitPoints;
        }
    }
}
