using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms
{
    public class JuryLeniency : Action
    {
        public static readonly int Amount = 1;
        
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
