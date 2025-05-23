﻿using IAcademyOfDoom.Logic.Actions;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.Logic.Places
{
    /// <summary>
    /// A class modelling a placeable item (that can become a room placed in one cell).
    /// </summary>
    public class Placeable
    {
        public readonly string name;
        /// <summary>
        /// The type of the room.
        /// </summary>
        public RoomType RoomType { get; private set; }

        
        /// <summary>
        /// The associated skill (for prof rooms) or null.
        /// </summary>
        public SkillType? Skill { get; private set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="roomType">the type of the room when placed</param>
        /// <param name="skill">the associated skill, or null</param>
        /// <param name="name">the name of the room, or null</param>
        public Placeable(RoomType roomType, SkillType? skill = null, string name = null)
        {
            RoomType = roomType;
            Skill = skill;
            this.name = name;
        }

        
        /// <summary>
        /// Turns this object into a room.
        /// </summary>
        /// <param name="x">the column</param>
        /// <param name="y">the row</param>
        /// <returns>a new room object</returns>
        public Room MakeRoom(int x, int y)
        {
            switch (RoomType)
            {
                case RoomType.Examination:
                    return new Room(x, y) { Name = name };
                case RoomType.SpawnArea:
                    return new SpawnArea();
                case RoomType.Prof:
                    if (Skill.HasValue)
                    {
                        return new ProfRoom(x, y) { Name = name, SkillType = Skill.Value };
                    }
                    else
                    {
                        return null;
                    }
                case RoomType.Facility:
                    switch (name)
                    {
                        case "Orientation":
                            return new Orientation(x, y) { Name = name };
                        case "Rest room":
                            return new RestRoom(x, y) { Name = name };
                        case "Party room":
                            return new PartyRoom(x, y) { Name = name };
                        case "Faculty lounge":
                            return new FacultyLounge(x, y) { Name = name };
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }
        /// <summary>
        /// ToString override for displaying info.
        /// </summary>
        /// <returns>a full representation</returns>
        public override string ToString()
        {
            if (name == null)
            {
                return "Room : " + RoomType.ToString() + "-" + Skill?.ToString() + "; ";
            }
            return name;
        }
    }
}
