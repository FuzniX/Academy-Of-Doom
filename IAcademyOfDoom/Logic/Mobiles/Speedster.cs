using System;
using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Mobiles
{
    public class Speedster : Botling
    {
        public Speedster() : base(BotType.Speedster) {}
        
        protected override (int x, int y) Next(List<Room> rooms, List<Direction> directions = null)
        {
            int length = 1;
            try
            {
                Direction bestDirection = BestDirection(rooms, directions);
                while (true)
                {
                    (int x, int y) = Next(bestDirection, length);
                    if ((x, y) == (Game.MaxX, Game.MaxY) || Game.FindRoomAt(x, y, rooms) is ProfRoom) return (x, y);
                    if (IsOutOfBounds(x, y)) {length--; return Next(bestDirection, length);}
                    length++;
                }
            }
            finally { if (length > 1) HP--; } // Decrease HP if, whatever it is, the move is of length 2 or more
        }

        protected static bool IsOutOfBounds(int x, int y)
        {
            return x < 0 || x > Game.MaxX || y < 0 || y > Game.MaxY;
        }
    }
}