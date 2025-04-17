using IAcademyOfDoom.App;
using IAcademyOfDoom.Logic.GameSequence;
using IAcademyOfDoom.Logic.GameSettings;
using IAcademyOfDoom.Logic.Mobiles;
using IAcademyOfDoom.Logic.Places;
using IAcademyOfDoom.Logic.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IAcademyOfDoom.Logic
{
    /// <summary>
    /// The class representing the game.
    /// Normally, only one instance at any time
    /// </summary>
    public class Game
    {
        #region public static (class-level) properties
        /// <summary>
        /// A random number generator (used everywhere).
        /// </summary>
        public static Random Random { get; } = new Random();
        /// <summary>
        /// The difficulty of the game.
        /// </summary>
        public static Difficulty Difficulty {  get; set; } = Difficulty.Easy;
        /// <summary>
        /// The maximum X (highest index for columns, starting at 0).
        /// </summary>
        public static int MaxX { get; private set; } = Default.Columns - 1;
        /// <summary>
        /// The maximum Y (highest index for rows, starting at 0).
        /// </summary>
        public static int MaxY { get; private set; } = Default.Lines- 1;
        #endregion
        #region public read-only instance properties
        /// <summary>
        /// A list of buyable items.
        /// </summary>
        public List<Buyable> buyables { get; } = new List<Buyable>();
        /// <summary>
        /// The current money of the player.
        /// </summary>
        public int Money { get; private set; }
        #endregion
        #region private attributes
        private Phase currentPhase = Phase.Preparation;
        private int waveNumber = 1;
        private Wave wave = null;
        private int successes;
        private int failures;
        private int deaths;
        private readonly List<Room> rooms = new List<Room>();
        private readonly List<Placeable> placeables = new List<Placeable>();
        private readonly List<Botling> botlings = new List<Botling>();
        private Controller c = Controller.Instance;
        #endregion
        #region constructor
        /// <summary>
        /// Constructor.
        /// Sets up base values
        /// </summary>
        public Game() { 
            rooms.Add(Room.SpawnArea());
            rooms.Add(Room.ExamRoom());
            placeables.Add(new Placeable(RoomType.Prof, SkillType.Classify, "Classification Professor"));
            placeables.Add(new Placeable(RoomType.Prof, SkillType.Produce, "Production Professor"));
            placeables.Add(new Placeable(RoomType.Prof, SkillType.Dialogue, "Dialogue Professor"));
            placeables.Add(new Placeable(RoomType.Prof, SkillType.Interpret, "Interpretation Professor"));
            placeables.Add(new Placeable(RoomType.Prof, SkillType.Synthetise, "Synthesis Professor"));
            placeables.Add(new Placeable(RoomType.Prof, SkillType.Present, "Presentation Professor"));
            buyables.Add(new Buyable(RoomType.Prof, Default.TutorCost, 1, "Analysys Tutor",SkillType.Analyse));
            buyables.Add(new Buyable(RoomType.Prof, Default.TutorCost,1, "Recognition Tutor",SkillType.Recognise));
            buyables.Add(new Buyable(RoomType.Prof, Default.TutorCost, 1, "Generation Tutor",SkillType.Generate));
            buyables.Add(new Buyable(RoomType.Prof, Default.TutorCost,1, "Communication Tutor", SkillType.Communicate));
            buyables.Add(new Buyable(RoomType.Facility, Default.ServiceCost,3, "Orientation"));
            buyables.Add(new Buyable(RoomType.Facility, Default.StudentCost,4, "Rest room"));
            buyables.Add(new Buyable(RoomType.Facility, Default.StudentCost, 4,"Party room"));
            buyables.Add(new Buyable(RoomType.Facility, Default.FacultyCost,4, "Faculty lounge"));
        }
        #endregion
        #region public methods
        /// <summary>
        /// Adds a room at one position given a placeable item.
        /// </summary>
        /// <param name="x">the column</param>
        /// <param name="y">the row</param>
        /// <param name="placeable">the placeable item</param>
        public void AddRoomHere(int x, int y, Placeable placeable)
        {
            rooms.Add(placeable.MakeRoom(x, y));
        }
        
        /// <summary>
        /// Provides a copy of the list of placeable items.
        /// </summary>
        /// <returns>a new list</returns>
        public List<Placeable> Placeables() => new List<Placeable>(placeables);
        
        /// <summary>
        /// Provide a public way of adding a placeable to the game class
        /// </summary>
        /// <param name="placeable"></param>
        public void AddPlaceable(Placeable placeable) {
            placeables.Add(placeable);
            
        }

        /// <summary>
        /// Provides a copy of the list of buyables items
        /// </summary>
        /// <returns>a new list</returns>
        public List<Buyable> Buyables() => new List<Buyable>(buyables);
        
        /// <summary>
        /// Update player's money
        /// </summary>
        /// <param name="price"></param>
        public void UpdateAmountOfMoney(int price) => this.Money -= price;
        
        /// <summary>
        /// Returns a copy of rooms' attribute
        /// </summary>
        /// <returns></returns>
        public List<Room> Rooms()
        {
            return new List<Room>(rooms);
        }
    
        /// <summary>
        /// Returns a copy of botlings' attribute
        /// </summary>
        /// <returns></returns>
        public List<Botling> Botlings() => new List<Botling>(botlings);
        
        /// <summary>
        /// Attempts to place a placeable item at some position.
        /// </summary>
        /// <param name="x">the column</param>
        /// <param name="y">the row</param>
        /// <param name="placeable">the candidate placeable item</param>
        /// <returns>true iff the placeable has been correctly placed</returns>
        public bool PlaceThisHere(int x, int y, Placeable placeable)
        {
            if (placeables.Contains(placeable))
            {
                AddRoomHere(x, y, placeable);
                placeables.Remove(placeable);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Ends the preparation phase and goes into the assault phase.
        /// </summary>
        public void EndPreparations()
        {
            currentPhase = Phase.Assault;
            successes = failures = deaths =  0;
            wave = new Wave(waveNumber);
        }
        /// <summary>
        /// Progresses in the assault phase.
        /// </summary>
        public void NextInAssault()
        {
            bool change = false;
            List<Botling> spawnedNow=null;
            List<Botling> terminatedNow=new List<Botling>();
            if (wave != null && wave.Turn != null)
            {
                spawnedNow=wave.Turn.SpawnOrNull();
            }
            if (botlings.Count > 0)
            {
                foreach (Botling botling in botlings)
                {
                    if (botling is Introvert introvert) introvert.Move(Rooms(), Botlings());
                    else botling.Move(Rooms());
                    (int x, int y) = (botling.X, botling.Y);
                    Room entered = FindRoomAt(x, y);
                    object result = entered?.ActOnEntry(botling);
                    if (result is ExamResult examResult)
                    {
                        StoreExamResult(examResult);
                        if (!(botling is Persistent) || examResult == ExamResult.Success)
                        {
                            terminatedNow.Add(botling);
                        }
                    }
                    else if (result is bool b)
                    {
                        if (entered is FacultyLounge)
                        {
                            foreach (Room room in Rooms())
                            {
                                if (room is ProfRoom profRoom)
                                {
                                    profRoom.HP += 10;
                                    if (profRoom.HP > Default.BaseProfHitPoints)
                                    {
                                        profRoom.HP = Default.BaseProfHitPoints;
                                    }
                                }
                            }
                        }
                        c.LessonResult(botling, b);
                        if (!b && botling.HP <= 0)
                        {
                            deaths++;
                            terminatedNow.Add(botling);
                        }
                    }
                }
                change = true;
            }
            if (spawnedNow?.Count > 0)
            {
                botlings.AddRange(spawnedNow);
                change = true;
            }
            if (change)
            {
                foreach(Botling removable in terminatedNow)
                {
                    botlings.Remove(removable);
                }
                c.BotRemove(terminatedNow);
                c.BotChange(botlings);
            }
            else
            {
                currentPhase = Phase.Result;
                wave = null;
                waveNumber++;
                c.EndAssault();
            }
        }
        /// <summary>
        /// Accesses the current results of the assault.
        /// </summary>
        /// <returns>a success - failures pair</returns>
        public (int successes, int failures, int deaths) GetResults()
        {
            return (successes, failures, deaths);
        }
        /// <summary>
        /// Removes a room.
        /// </summary>
        /// <param name="profRoom">the room to remove</param>
        public void DestroyRoom(ProfRoom profRoom)
        {
            rooms.Remove(profRoom);
        }
        /// <summary>
        /// Goes to the next wave.
        /// </summary>
        /// <returns>false: game over</returns>
        public bool NextWave()
        {
            return waveNumber <= 2;
           
        }

        /// <summary>
        /// Initilialize base money with current difficulty
        /// </summary>
        public void InitializeMoney()
        {
            Money = Default.BaseMoney(Difficulty);
        }
        
        public static Room FindRoomAt(int x, int y, List<Room> rooms)
        {
            int i = 0;
            int index = -1;
            if (rooms == null) return null;
            
            while (index == -1 && i < rooms.Count)
            {
                if (rooms[i]?.X==x && rooms[i]?.Y==y)
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
        
        #endregion
        #region private methods
        private void StoreExamResult(ExamResult examResult)
        {
            switch (examResult)
            {
                case ExamResult.Success:
                    successes++;
                    break;
                case ExamResult.Failure:
                    failures++;
                    break;
            }
        }
        private Room FindRoomAt(int x, int y)
        {
            int i = 0;
            int index = -1;
            while (index == -1 && i < rooms.Count)
            {
                if (rooms[i]?.X==x && rooms[i]?.Y==y)
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
        #endregion
    }
}