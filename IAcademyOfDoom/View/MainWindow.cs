﻿using IAcademyOfDoom.App;
using IAcademyOfDoom.Logic.GameSettings;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;
using IAcademyOfDoom.Logic.Skills;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IAcademyOfDoom.Logic.Actions;

namespace IAcademyOfDoom.View
{
    /// <summary>
    /// The main window.
    /// </summary>
    public partial class MainWindow : Form
    {
        #region private attributes
        private Controller c = Controller.Instance;
        private readonly List<BotlingView> bots = new List<BotlingView>();
        private readonly List<RoomView> rooms = new List<RoomView>();
        private readonly List<PlaceableView> placeables = new List<PlaceableView>();
        private readonly List<ActionView> actions = new List<ActionView>();
        private PlaceableView currentPlaceable = null;
        private ActionView currentAction = null;
        private Point currentActionMoveStart;
        private Point currentActionOriginLocation;
        private RoomView currentRoom = null;
        private Point currentRoomMoveStart;
        private Point currentRoomOriginLocation;
        private BotlingView hoveredBotling;
        

        #endregion

        #region constructor

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public MainWindow()
        {
            Difficulty? difficulty = null;
            string name = null;
            DifficultySelect select = new DifficultySelect();
            select.ShowDialog();
            name = select.InputName;
            difficulty = select.Difficulty;
            Refresh();

            InitializeComponent();
            c.Associate(this, name, difficulty);
            if (c.Name != null)
            {
                playerNameLabel.Text = "Player: " + c.Name;
                playerNameLabel.Visible = true;
            }
            else
            {
                playerNameLabel.Visible = false;
            }
        }

        #endregion

        #region event handling methods

        /// <summary>
        /// Event handling: Paint
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">used to get the graphic context</param>
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            numberOfBotlingsContentLabel.Text = bots.Count.ToString();
            foreach (PlaceableView placeable in placeables)
            {
                placeable.Draw(e.Graphics);
            }

            foreach (ActionView action in actions)
            {
                action.Draw(e.Graphics);
            }

            BackgroundGrid(e.Graphics);
            SyncRooms();
            foreach (RoomView room in rooms)
            {
                room.Draw(e.Graphics);
            }

            foreach (BotlingView bot in bots)
            {
                bot.Draw(e.Graphics);
            }

            MoneyAmountLabel.Text = "" +  c.GetAvailableMoney();


            if (hoveredBotling != null)
            {
                Pen arrowPen = new Pen(Color.Blue, 2);
                (Point start, Point end) = ArrowCoordinates();
                e.Graphics.DrawLine(arrowPen, start, end);
            }
        }

        private void EndPrepButton_Click(object sender, EventArgs e)
        {
            if (c.CanEndPreparations())
            {
                c.EndPreparations();
            }
            else
            {
                GiveInformation("Preparations are not complete yet.");
            }
        }

        /// <summary>
        /// Event handling: click on next in assault button.
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void NextInAssaultButton_Click(object sender, EventArgs e)
        {
            c.NextInAssault();
        }
        /// <summary>
        /// Event handling: click to open shop window
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void shopButton_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop(c);
            shop.Show();
        }
        /// <summary>
        /// Event handling: click on quit button.
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void QuitButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Event handling: Mouse button down
        /// </summary>
        /// <param name="sender">ignore</param>
        /// <param name="e">used for pointer location and mouse button id</param>
        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            (int x, int y) = PointCoordinates(e.Location);
            if (e.Button == MouseButtons.Left && endPrepButton.Enabled)
            {
                if (!c.CanEndPreparations() && c.Placeables().Count > 0 && RoomHere(e.Location) == null)
                {
                    if(!(x, y).Equals((-1, -1)))
                    {
                        Placeable placeableP = c.Placeables()[0];
                        c.PlaceHere(x, y, placeableP);
                    }
                    
                    foreach (PlaceableView placeable in placeables)
                    {
                        
                        if (placeable.OnSquare(e.Location))
                        {
                            // We assume that there is only one placeable that matches current location,
                            // so this should be redefined only once here.
                            currentPlaceable = placeable;
                        }
                    }
                }

                if (c.CanEndPreparations() || c.Placeables().Count > 0)
                {
                    currentRoom = RoomHere(e.Location);
                    currentRoomMoveStart = e.Location;
                    if (currentRoom != null)
                    {
                        currentRoomOriginLocation = currentRoom.Location;
                        if (currentRoom.Room.Type == RoomType.SpawnArea || currentRoom.Room.Type == RoomType.Examination) { currentRoom = null; }
                    }
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                foreach (ActionView action in actions)
                {
                    if (action.OnSquare(e.Location))
                    {
                        currentAction = action;
                        currentActionMoveStart = e.Location;
                        currentActionOriginLocation = action.Location;
                    }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                Botling target = BotlingHere(e.Location); 
                if (target == null)
                {
                    RoomView roomTarget = RoomHere(e.Location);
                    if (roomTarget != null && (roomTarget.Room.Type != RoomType.SpawnArea || roomTarget.Room.Type != RoomType.Examination))
                    {
                        MessageBox.Show(DisplayStateOf(roomTarget));
                    }
                }
                else
                {
                    MessageBox.Show(DisplayStateOf(target));
                }
            }
        }

        /// <summary>
        /// Event handling: Mouse button up
        /// </summary>
        /// <param name="sender">ignore</param>
        /// <param name="e">used for pointer location and mouse button id</param>
        private void MainWindow_MouseUp(object sender, MouseEventArgs e)
        {
            (int x, int y) = PointCoordinates(e.Location);
            if (e.Button == MouseButtons.Left && endPrepButton.Enabled)
            {
                if (!c.CanEndPreparations() && c.Placeables().Count > 0 && RoomHere(e.Location) == null &&
                    !(x, y).Equals((-1, -1)) && currentPlaceable != null)
                {
                    Placeable placeable = currentPlaceable.Placeable;
                    c.PlaceHere(x, y, placeable);
                }

                if (currentRoom != null)
                {
                    if (RoomHere(e.Location).Location == ConvertCoordinates(x, y))
                    {
                        currentRoom.Location = currentRoomOriginLocation;
                    }
                    else
                    {
                        currentRoom.Location = ConvertCoordinates(x, y);
                        currentRoom.UpdateRoomCoordinates();
                    }
                    Refresh();
                }
                
            }

            if (e.Button == MouseButtons.Left && currentAction != null)
            {
                ActionType? result = c.PlaceAction(x, y, currentAction.PlaceableAction);
                if (result != null)
                {
                    currentAction.Location = currentActionOriginLocation;
                    string requirement;
                    switch (result)
                    {
                        case ActionType.PremisesRenovation:
                            requirement = "Prof Room";
                            break;
                        case ActionType.JuryLeniency:
                            requirement = "Room";
                            break;
                        default:
                            requirement = "Nothing!";
                            break;
                    }
                    MessageBox.Show("You need to aim at a " + requirement);
                }
            }
            
            currentPlaceable = null;
            currentRoom = null;
            currentAction = null;
        }

        /// <summary>
        /// Event handling: mouse move
        /// </summary>
        /// <param name="sender">ignore</param>
        /// <param name="e">user for pointer location and mouse button id</param>
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && endPrepButton.Enabled)
            {
                if (currentPlaceable != null)
                {
                    currentPlaceable.Location = e.Location;
                    Refresh();
                }

                if (currentRoom != null)
                {
                    Point current = currentRoom.Location;
                    current.Offset(e.Location.X - currentRoomMoveStart.X, e.Location.Y - currentRoomMoveStart.Y);
                    currentRoom.Location = current;
                    currentRoomMoveStart = e.Location;
                    Refresh();
                }
            }
            
            if (e.Button == MouseButtons.Left && currentAction != null)
            {
                currentAction.Location = e.Location;
                Refresh();
            }
            
            Botling b = BotlingHere(e.Location);
            if (b == null)
            {
                if (hoveredBotling != null)
                {
                    hoveredBotling = null;
                    Refresh();
                }
                
            } 
            else
            {
                foreach (BotlingView bot in bots)
                {
                    if (bot.Botling.Equals(b))
                    {
                        hoveredBotling = bot;
                    }
                }
                Refresh();
            }
            
              
        }

        private void ResultsBtn_Click(object sender, EventArgs e)
        {
            c.ShowResults();
        }

        private void InformationBtn_Click(object sender, EventArgs e)
        {
            new Information().Show();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Method called by the controller to set the window to assault mode.
        /// </summary>
        public void SetToAssault()
        {
            endPrepButton.Visible = false;
            nextInAssaultButton.Visible = true;
            GiveInformation("Assault!");
        }

        /// <summary>
        /// Method called by the controller to update the display in asault mode.
        /// </summary>
        public void AssaultUpdate()
        {
            if (nextInAssaultButton.Visible)
            {
                rooms.ForEach(roomView => roomView.SyncLocation());
            }
        }

        /// <summary>
        /// Method called by the controller to set the window to results mode.
        /// </summary>
        /// <param name="results">the results of the previous wave, as a pair</param>        
        public void DisplayResults((int successes, int failures, int deaths) results)
        {
            endPrepButton.Visible = true;
            nextInAssaultButton.Visible = false;
            Refresh();
            c.NextWave();
        }

        /// <summary>
        /// Method called by the controller to update the botling mobiles.
        /// </summary>
        /// <param name="botlings"></param>
        public void UpdateBots(List<Botling> botlings)
        {
            Dictionary<(int x, int y), List<Botling>> newBotlingsByRoom =
                new Dictionary<(int x, int y), List<Botling>>();
            Dictionary<(int x, int y), List<Botling>> oldBotlingsByRoom =
                new Dictionary<(int x, int y), List<Botling>>();
            foreach (Botling botling in botlings)
            {
                bool add = true;
                int i = 0;
                while (i < bots.Count && add)
                {
                    if (bots[i].Botling.Equals(botling))
                    {
                        add = false;
                    }
                    else
                    {
                        i++;
                    }
                }

                if (add)
                {
                    PutBotlingInListByRoom(newBotlingsByRoom, botling);
                }
                else
                {
                    PutBotlingInListByRoom(oldBotlingsByRoom, botling);
                }
            }

            foreach ((int x, int y) in newBotlingsByRoom.Keys)
            {
                int deltaX = 0, deltaY = 0;
                foreach (Botling botling in newBotlingsByRoom[(x, y)])
                {
                    Point point = ConvertCoordinates(x, y);
                    bots.Add(new BotlingView(new Point(point.X + deltaX, point.Y + deltaY), botling));
                    deltaX += Settings.BotlingSize.Width * 2;
                    if (deltaX > Settings.Width - Settings.BotlingSize.Width)
                    {
                        deltaX = 0;
                        deltaY += Settings.BotlingSize.Height * 2;
                    }
                }
            }

            foreach ((int x, int y) in oldBotlingsByRoom.Keys)
            {
                int deltaX = 0, deltaY = 0;
                foreach (Botling botling in oldBotlingsByRoom[(x, y)])
                {
                    BotlingView view = null;
                    int i = 0;
                    while (i < bots.Count && view == null)
                    {
                        if (bots[i].Botling.Equals(botling))
                        {
                            view = bots[i];
                        }
                        else
                        {
                            i++;
                        }
                    }

                    if (view != null)
                    {
                        (int baseX, int baseY) = ConvertCoordinates(view.Location);
                        Point newLoc = ConvertCoordinates(x, y);
                        Point arrival = new Point(newLoc.X + (baseX + deltaX) % Settings.Width,
                            newLoc.Y + (baseY + deltaY) % Settings.Width);
                        view.Location = arrival;
                        deltaX += Settings.BotlingSize.Width * 2;
                        if (baseX + deltaX > Settings.Width - Settings.BotlingSize.Width)
                        {
                            deltaX = 0;
                            deltaY += Settings.BotlingSize.Height * 2;
                        }
                    }
                }
            }
            Refresh();
        }

        /// <summary>
        /// Writes to the output list box.
        /// </summary>
        /// <param name="s">the string to be written</param>
        public void GiveInformation(string s)
        {
            InformationGiver.Text = s;
            InformationGiver.Refresh();
        }

        /// <summary>
        /// Converts a logical pair of coordinates to a graphic point.
        /// </summary>
        /// <param name="x">the column id</param>
        /// <param name="y">the row id</param>
        /// <returns>the top left corner of the graphical cell or a problematic point if outside of the range</returns>
        public static Point ConvertCoordinates(int x, int y)
        {
            return new Point(Settings.Left + x * Settings.Width, Settings.Top + y * Settings.Height);
        }

        /// <summary>
        /// Converts a point to the offset from the top-left corner of its cell.
        /// </summary>
        /// <param name="point">the point</param>
        /// <returns>a pair of offset coordinates, in pixels</returns>
        public static (int x, int y) ConvertCoordinates(Point point)
        {
            return ((point.X - Settings.Left) % Settings.Width, (point.Y - Settings.Top) % Settings.Height);
        }

        /// <summary>
        /// Method called by the controller to remove some botlings.
        /// </summary>
        /// <param name="removed">a list of logical botlings to remove</param>
        public void RemoveBots(List<Botling> removed)
        {
            List<BotlingView> views = new List<BotlingView>();
            foreach (Botling bot in removed)
            {
                foreach (BotlingView view in bots)
                {
                    if (view.Botling.Equals(bot))
                    {
                        views.Add(view);
                    }
                }
            }

            foreach (BotlingView view in views)
            {
                bots.Remove(view);
            }
        }

        /// <summary>
        /// Method called by the controller to update the placeable items.
        /// </summary>
        /// <param name="placeables">the current list of placeables</param>
        public void PreviewPlaceableItems(List<Placeable> placeables)
        {
            this.placeables.Clear();
            if (placeables.Count == 0)
            {
                GiveInformation("All items placed !");
                return;
            }

            string items = "";
            int x = Settings.PlaceableLeft;
            int y = Settings.PlaceableTop;

            foreach (Placeable placeable in placeables)
            {
                items += " " + placeable.ToString();
                this.placeables.Add(new PlaceableView(placeable, new Point(x, y)));
                y += Settings.PlaceableOffset;
            }

            Refresh();
        }
        
        /// <summary>
        /// Method called by the controller to update the placeable actions.
        /// </summary>
        /// <param name="placeables">the current list of placeable actions</param>
        public void PreviewPlaceableItems(List<PlaceableAction> actions)
        {
            this.actions.Clear();
            if (actions.Count == 0) return;
            
            int x = Settings.ActionLeft;
            int y = Settings.ActionTop;

            foreach (PlaceableAction action in actions)
            {
                this.actions.Add(new ActionView(action, new Point(x, y)));
                y += Settings.PlaceableOffset;
            }
            Refresh();
        }

        /// <summary>
        /// Method displaying the current status of a logical botling mobile.
        /// </summary>
        /// <param name="botling">the logical botling</param>
        public string DisplayStateOf(Botling botling)
        {
            string name = botling.Name;
            string hp = botling.HP.ToString() + " HP";
            string skills = "Skills: ";
            foreach (SkillType skill in botling.Skills.Keys)
            {
                skills += "[" + skill.ToString() + "]" + "=" + botling.Skills[skill] + " ";
            }

            string badges = "Badges:";
            foreach (SkillType skill in botling.Badges.Keys)
            {
                if (botling.Badges[skill])
                {
                    badges += "[" + skill.ToString() + "] ";
                }
            }

            if (badges.EndsWith(":"))
            {
                badges += " none";
            }

            return "Botling " + name + ": " + hp + "\n  " + skills + "\n  " + badges + "\n  Orientation: " + botling.Orientation + "\n  Type: " + botling.Type;
        }

        public string DisplayStateOf(RoomView room)
        {
            string name = room.Room.Name;
            Point location = room.Location;
            RoomType roomType = room.Room.Type;

            return "Room " + name + ":\n  " + roomType + "\n  (" + location.X + ", " + location.Y + ")";
        }

        /// <summary>
        /// Method called by the controller when the game is over.
        /// </summary>
        public void GameOver()
        {
            GiveInformation("Game over.");
            nextInAssaultButton.Enabled = false;
            endPrepButton.Enabled = false;
            quitButton.Enabled = true;
            quitButton.Visible = true;
        }

        #endregion

        #region private mehods

        private Botling BotlingHere(Point location)
        {
            int i = 0;
            int index = -1;
            while (index == -1 && i < bots.Count)
            {
                if (bots[i].Contains(location))
                {
                    index = i;
                }
                else
                {
                    i++;
                }
            }

            if (index == -1)
            {
                return null;
            }
            else
            {
                return bots[index].Botling;
            }
        }

        private (Point start, Point end) ArrowCoordinates()
        {
            int directionX = hoveredBotling.Botling.NextMove.x - hoveredBotling.Botling.X;
            int directionY = hoveredBotling.Botling.NextMove.y - hoveredBotling.Botling.Y;
            Point start = new Point(hoveredBotling.Center.X, hoveredBotling.Center.Y);
            Point end = new Point(hoveredBotling.Center.X + (directionX * 25), hoveredBotling.Center.Y + (directionY * 25));
            
            return (start, end);
        }

        public static (int x, int y) PointCoordinates(Point point)
        {
            int posX = point.X;
            int posY = point.Y;
            if (posX >= Settings.Left && posY >= Settings.Top &&
                posX < Settings.Width * Settings.Cols + Settings.Left &&
                posY < Settings.Height * Settings.Rows + Settings.Top)
            {
                return ((posX - Settings.Left) / Settings.Width, (posY - Settings.Top) / Settings.Height);
            }
            else
            {
                return (-1, -1);
            }
        }

        private void SyncRooms()
        {
            foreach (Room r in c.Rooms())
            {
                bool add = true;
                int i = 0;
                while (i < rooms.Count && add)
                {
                    if (rooms[i].Room.Equals(r))
                    {
                        add = false;
                    }
                    else
                    {
                        i++;
                    }
                }

                if (add)
                {
                    rooms.Add(RoomView.CreateFromRoom(r));
                }
            }

            List<RoomView> checkList = new List<RoomView>(rooms);
            foreach (RoomView view in checkList)
            {
                if (!c.Rooms().Contains(view.Room))
                {
                    rooms.Remove(view);
                }
            }
        }

        private static void BackgroundGrid(Graphics graphics)
        {
            for (int i = 0; i < Settings.Cols; i++)
            {
                for (int j = 0; j < Settings.Rows; j++)
                {
                    Rectangle r = new Rectangle(ConvertCoordinates(i, j), new Size(Settings.Width, Settings.Height));
                    graphics.DrawRectangle(Settings.Pen, r);
                }
            }
        }

        private RoomView RoomHere(Point location)
        {
            int i = 0;
            int index = -1;
            while (index == -1 && i < rooms.Count)
            {
                if (rooms[i].Contains(location))
                {
                    index = i;
                }
                else
                {
                    i++;
                }
            }

            if (index == -1)
            {
                return null;
            }
            else
            {
                return rooms[index];
            }
        }

        private void PutBotlingInListByRoom(Dictionary<(int x, int y), List<Botling>> list, Botling botling)
        {
            if (!list.ContainsKey((botling.X, botling.Y)))
            {
                list.Add((botling.X, botling.Y), new List<Botling>());
            }

            list[(botling.X, botling.Y)].Add(botling);
        }

        public void ClearActions()
        {
            actions.Clear();
        }
        
        #endregion
    }
}