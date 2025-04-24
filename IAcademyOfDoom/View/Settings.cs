using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;
using System.Drawing;
using IAcademyOfDoom.Logic;
using IAcademyOfDoom.Logic.GameSettings;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.View
{
    /// <summary>
    /// This non-instanciated class contains the settings for the graphics display.
    /// </summary>
    public static class Settings
    {
        public static int Cols { get; } = Default.Columns;
        public static int Rows { get; } = Default.Lines;
        public static int Width { get; } = 80;
        public static int Height { get; } = 70;
        public static int Left { get; } = 40;
        public static int Top { get; } = 100;
        public static Pen Pen { get; } = Pens.White;
        public static Size BotlingSize { get; } = new Size(15, 15);

        public static Size SkillOffset { get; } = new Size(5, 5);

        public static int SkillSide { get; } = 10;
        public static Size TextOffset { get; } = new Size(5, Height/2);
        public static Brush TextBrush { get; } = Brushes.White;
        public static Font RoomFont { get; } = SystemFonts.IconTitleFont;
        
        public static int PlaceableLeft = Left + Width * Cols + 75;
        public static int PlaceableTop = Top + 50;
        
        public static int ActionLeft = Left + Width * Cols + 300;
        public static int ActionTop = Top + 50;
        
        public static Size WindowSize { get; } = new Size(Left + Width * Cols + 600, Top + Height * Rows + 50);
        
        public static Size PlaceableSquare { get; } = new Size(15, 15);
        public static int PlaceableOffset { get; } = 20;
        
        public static Image PlaceableImage = Image.FromFile("Resources/placeable.png");
        
        public static Image ActionImage = Image.FromFile("Resources/action.png");
        

        public static Image GetBotImageFor(BotType type)
        {
            switch (type)
            {
                case BotType.Speedster:
                    return Image.FromFile("Resources/speedster.png");
                case BotType.Perfectionnist:
                    return Image.FromFile("Resources/perfectionnist.png");
                case BotType.Introvert:
                    return Image.FromFile("Resources/introvert.png");
                case BotType.Lucky:
                    return Image.FromFile("Resources/lucky.png");
                case BotType.Aimless:
                    return Image.FromFile("Resources/aimless.png");
                case BotType.Persistent:
                    return Image.FromFile("Resources/persistent.png");
                case BotType.None:
                default:
                    return Image.FromFile("Resources/botling.png");
            }
        }

        public static Image GetRoomImageFor(RoomType rType)
        {
            string path;
            switch (rType)
            {
                case RoomType.Examination:
                    path = "classroom.png";
                    break;
                case RoomType.SpawnArea:
                    path = "spawnarea.png";
                    break;
                case RoomType.Prof:
                    path = "profroom.png";
                    break;
                case RoomType.Facility:
                    path = "facility.png";
                    break;
                default:
                    path = "classroom.png";
                    break;
            }
            return Image.FromFile("Resources/" + path);
        }

        public static Brush GetSkillColourFor(SkillType skillType)
        {
            switch (skillType)
            {
                case SkillType.Analyse:
                    return Brushes.White;
                case SkillType.Recognise:
                    return Brushes.Green;
                case SkillType.Generate:
                    return Brushes.Red;
                case SkillType.Communicate:
                    return Brushes.Orange;
                case SkillType.Classify:
                    return Brushes.Aqua;
                case SkillType.Produce:
                    return Brushes.Blue;
                case SkillType.Dialogue:
                    return Brushes.Chartreuse;
                case SkillType.Interpret:
                    return Brushes.DeepPink;
                case SkillType.Present:
                    return Brushes.LightSeaGreen;
                case SkillType.Synthetise:
                    return Brushes.Yellow;
                default:
                    return Brushes.Black;
            }
        }
    }
}
