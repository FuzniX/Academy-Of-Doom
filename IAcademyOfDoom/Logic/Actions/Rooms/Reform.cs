using System;
using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms
{
    public class Reform : Action
    {
        public const int Amount = 1;
        
        private readonly List<Room> rooms;
        
        public Reform(string name, List<Room> rooms) : base(name)
        {
            this.rooms = rooms;
        }

        public override void Execute()
        {
            rooms.ForEach(room =>
            {
                if ((room.X != 0 && room.Y != 0) && (room.X != Game.MaxX && room.Y != Game.MaxY))
                {
                    while (true)
                    {
                        (int x, int y) = (Game.Random.Next(0, Game.MaxX), Game.Random.Next(0, Game.MaxY));
                        if (Game.FindRoomAt(x, y, rooms) == null)
                        {
                            room.X = x;
                            room.Y = y;
                        }
                    }
                }
            });
        }
    }
}
