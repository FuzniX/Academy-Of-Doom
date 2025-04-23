using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.View
{
    public class ActionView
    {
        public readonly PlaceableAction PlaceableAction;
        
        public Point Location { get; set; }

        public ActionView(PlaceableAction placeableAction, Point location)
        {
            PlaceableAction = placeableAction;
            Location = location;
        }

        

        /// <summary>
        /// Method displaying the graphics.
        /// </summary>
        /// <param name="graphics">a reference to the graphic context to be used</param>
        public void Draw(Graphics graphics)
        {
            Point p = new Point(Location.X + Settings.TextOffset.Width, Location.Y);
            Rectangle rectangle = new Rectangle(Location, Settings.PlaceableSquare);
            graphics.FillRectangle(Settings.PlaceableSquareBrush, rectangle);
            graphics.DrawString("Placeable: " + PlaceableAction.ToString(), Settings.RoomFont, Settings.TextBrush, p);
        }
        /// <summary>
        /// Method checking whether a point is on the square next to the placeable item's display.
        /// </summary>
        /// <param name="point">the point</param>
        /// <returns>true iff the point is inside the square</returns>
        public bool OnSquare(Point point)
        {
            Rectangle rectangle = new Rectangle(Location, Settings.PlaceableSquare);
            return rectangle.Contains(point);
        }
    }
}
