using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Mobiles
{
    public class Aimless : Botling
    {
        public Aimless() : base(BotType.Aimless) {}
        
        public void Move(List<Room> rooms, List<Botling> botlings)
        {
            (X, Y) = NextMove;
            NextMove = Next(rooms, botlings);
        }
        
        protected (int x, int y) Next(List<Room> rooms, List<Botling> botlings)
        {
            return AreAllAimless(botlings) ? base.Next(rooms) : base.Next(rooms, AllDirections());
        }

        private static List<Direction> AllDirections() => new List<Direction>
            { Direction.Down, Direction.Left, Direction.Right, Direction.Up };

        private bool AreAllAimless(List<Botling> botlings)
        {
            foreach (Botling botling in botlings)
            {
                if (!(botling is Aimless)) return false;
            }
            return true;
        }
    }
}