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
        
        protected (int x, int y) Next(List<Room> rooms, List<Botling> botlings)
        {
            return BotlingHere(botlings) ? (X, Y) : base.Next(rooms);
        }

        private bool BotlingHere(List<Botling> botlings)
        {
            foreach (Botling botling in botlings)
            {
                if (botling.X == X && botling.Y == Y) return true;
            }

            return false;
        }
    }
}