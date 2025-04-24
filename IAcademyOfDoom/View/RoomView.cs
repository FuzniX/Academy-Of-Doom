using System;
using IAcademyOfDoom.Logic.Places;
using System.Drawing;
using System.IO;

namespace IAcademyOfDoom.View
{
    public class RoomView
    {
        public Point Location { get; set; }

        public string Label { get; set; }
        public Image BackImage { get; set; }
        public Room Room { get; set; } = null;

        public RoomView(Point location, string label, Image backImage)
        {
            Location = location;
            label = label.Length > 12 ? label.Insert(12, "\n") : label;
            Label = label;
            BackImage = backImage;
        }

        public static RoomView CreateFromRoom(Room r)
        {
            Point p = MainWindow.ConvertCoordinates(r.X, r.Y);
            return new RoomView(p, r.Name, Settings.GetRoomImageFor(r.Type))
            {
                Room = r
            };
        }

        /// <summary>
        /// Method displaying the graphics.
        /// </summary>
        /// <param name="graphics">a reference to the graphic context to be used</param>
        public void Draw(Graphics graphics)
        {
            Rectangle r = new Rectangle(Location, new Size(Settings.Width, Settings.Height));
            graphics.DrawImage(BackImage, r);
            graphics.DrawRectangle(Settings.Pen, r);
            // graphics.DrawString(Label, Settings.RoomFont, Settings.TextBrush,
            //     new Point(r.X + Settings.TextOffset.Width, r.Y + Settings.TextOffset.Height));
            if (Room is ProfRoom profRoom)
            {
                Rectangle skillRect = new Rectangle(
                    new Point(Location.X + Settings.SkillOffset.Width, Location.Y + Settings.SkillOffset.Height), 
                    new Size(Settings.SkillSide, Settings.SkillSide));
                graphics.FillRectangle(Settings.GetSkillColourFor(profRoom.SkillType), skillRect);
            }
            
            
        }

        /// <summary>
        /// Method checking whether a point is contained in the representation (bounding box).
        /// </summary>
        /// <param name="point">the point</param>
        /// <returns>true iff the point is within the graphic representation of the object</returns>
        public bool Contains(Point p)
        {
            return new Rectangle(Location, new Size(Settings.Width, Settings.Height)).Contains(p);
        }

        public void UpdateRoomCoordinates()
        {
            if (Room != null) (Room.X, Room.Y) = MainWindow.PointCoordinates(Location);
        }

        public void SyncLocation()
        {
            Location = MainWindow.ConvertCoordinates(Room.X, Room.Y);
        }
    }
}