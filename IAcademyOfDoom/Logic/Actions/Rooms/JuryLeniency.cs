using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms
{
    public class JuryLeniency : Action
    {
        public const int Amount = 1;
        
        private readonly Room room;
        
        public JuryLeniency(string name, Room room) : base(name)
        {
            this.room = room;
        }

        public override void Execute()
        {
            room.ForceSuccess = true;
        }
    }
}
