﻿using IAcademyOfDoom.Logic.Mobiles;
using System;
using System.Drawing;

namespace IAcademyOfDoom.View
{
    /// <summary>
    /// A class giving the graphic representation of a botling mobile.
    /// </summary>
    public class BotlingView
    {
        /// <summary>
        /// The logical botling refered by this graphic object.
        /// </summary>
        public Botling Botling {  get; set; }
        /// <summary>
        /// The location - top left corner.
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// The size - diameter w x h.
        /// </summary>
        public Size Size { get; set; }
        /// <summary>
        /// The solid colour to use.
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// The center of the ellipse.
        /// </summary>
        public Point Center =>
            new Point(Location.X + Size.Width/2,
                Location.Y + Size.Height / 2);

        /// <summary>
        /// Parametered constructor.
        /// </summary>
        /// <param name="location">the top left corner</param>
        /// <param name="botling">the logical botling</param>
        public BotlingView(Point location, Botling botling)
        {
            Location = location;
            Image = Settings.GetBotImageFor(botling.Type);
            Size = Settings.BotlingSize;
            Botling = botling;
        }
        /// <summary>
        /// Method displaying the graphics.
        /// </summary>
        /// <param name="graphics">a reference to the graphic context to be used</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image, new Rectangle(Location, Size));
        }
        /// <summary>
        /// Method checking whether a point is contained in the representation (bounding box).
        /// </summary>
        /// <param name="point">the point</param>
        /// <returns>true iff the point is within the graphic representation of the object</returns>
        public bool Contains(Point point)
        {
            return Math.Abs(point.X-Center.X) <= Size.Width/2 && Math.Abs(point.Y-Center.Y) < Size.Height/2;
        }
    }
}