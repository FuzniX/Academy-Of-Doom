using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.Logic.Places
{
    public class SpawnArea : Room
    {
        public SpawnArea() : base(0, 0)
        {
            Name = "Spawn area";
            Type = RoomType.SpawnArea;
        }

        /// <summary>
        /// What happens when a botling enters this room.
        /// </summary>
        /// <param name="botling">the botling entering the room</param>
        /// <returns>true</returns>
        public override object ActOnEntry(Botling botling) => true;
    }
}