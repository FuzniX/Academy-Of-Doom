using System;
using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Mobiles
{
    public class Speedster : Botling
    {
        public Speedster() : base(BotType.Speedster) {}
        
        protected override (int x, int y) Next(List<Room> rooms)
        {
            int length = 0;

            try
            {
                while (true)
                {
                    if (Orientation)
                    {
                        switch (BestDirection(X + length, Y + length, rooms))
                        {
                            case 0: return (X + length, Y);
                            case 1: return (X, Y + length);
                            case -2: return Game.Random.Next() %2 == 0 ? (X + length, Y) : (X, Y + length);
                        }
                    }
                    else
                    {
                        if (Game.FindRoomAt(X + length, Y, rooms) != null) return (X + length, Y);
                        if (Game.FindRoomAt(X, Y + length, rooms) != null) return (X, Y + length);
                    }
                    
                    if (X + length >= Game.MaxX && X < Game.MaxX) return (X + length, Y);
                    if (Y + length >= Game.MaxY && Y < Game.MaxY) return (X, Y + length);
                    length++;
                }
            }
            finally { if (length > 1) HP--; } // Decrease HP if, whatever it is, the move is of length 2 or more
        }
    }
}