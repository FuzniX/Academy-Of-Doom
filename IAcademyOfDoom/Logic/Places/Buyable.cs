﻿using IAcademyOfDoom.Logic.Skills;
using System.Xml.Linq;

namespace IAcademyOfDoom.Logic.Places
{
    /// <summary>
    /// Class stub for a possible buyable item that could be placed.
    /// </summary>
    public class Buyable
    {
        private readonly string name;
        /// <summary>
        /// The type of the room.
        /// </summary>
        public RoomType RoomType { get; private set; }
        /// <summary>
        /// The associated skill (for prof rooms) or null.
        /// </summary>
        public SkillType? Skill { get; private set; }

        private int price;

        private int quantity;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="roomType"></param>
        /// <param name="price"></param>
        /// <param name="name"></param>
        /// <param name="skill"></param>
        public Buyable(RoomType roomType, int priceRoom, int quantityOfRooms, string name = null, SkillType? skill = null)
        {
            this.RoomType = roomType;
            this.price = priceRoom;
            this.Skill = skill;
            this.name = name;
            this.quantity = quantityOfRooms;
        }
        /// <summary>
        /// Turns this in a placeable item.
        /// </summary>
        /// <returns>null</returns>
        public Placeable MakePlaceable() {
            switch (RoomType)
            {
                case RoomType.Facility:
                    return new Placeable(RoomType, null, name) ;
                case RoomType.Prof:
                    if (Skill.HasValue)
                    {
                        return new Placeable(RoomType,Skill,name);
                    }
                    else
                    {
                        return null;
                    }
                default:
                    return null;
            }
        }

        public string getName() => name;

        public int getPrice() => price;

        public int getQuantity() => quantity;

        public void decrementQuantity() => quantity--;
        /// <summary>
        /// ToString override for displaying info.
        /// </summary>
        /// <returns>a full representation</returns>
        public override string ToString()
        {
            return name + "-" + price + "$" + "  x" + quantity;
        }
    }
}