using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Mobiles
{
    public class Introvert : Botling
    {
        public Introvert() : base(BotType.Introvert) {}
        
        /// <summary>
        /// Enact the move.
        /// </summary>
        public void Move(List<Room> rooms, List<Botling> botlings)
        {
            (X, Y) = NextMove;
            NextMove = Next(rooms, botlings);
        }
        
        public (int x, int y) Next(List<Room> rooms, List<Botling> botlings)
        {
            (int x, int y) = base.Next(rooms);
            return BotlingAt(botlings, x, y) ? (X, Y) : (x, y);
        }

        private bool BotlingAt(List<Botling> botlings, int x, int y)
        {
            foreach (Botling botling in botlings)
            {
                if (botling.X == x && botling.Y == y) return true;
            }

            return false;
        }
    }
}