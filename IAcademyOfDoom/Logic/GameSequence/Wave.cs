using IAcademyOfDoom.Logic.Mobiles;
using System.Collections.Generic;

namespace IAcademyOfDoom.Logic.GameSequence
{
    /// <summary>
    /// A class containing the initialisation for turns.
    /// </summary>
    public class Wave
    {
        /// <summary>
        /// The current turn, null if the game is over/not started.
        /// </summary>
        public Turn Turn { get; private set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="waveNumber">the number of the current wave.</param>
        public Wave(int waveNumber) {
            Turn = null;
            switch (waveNumber)
            {
                case 1:
                    Turn = new Turn(8, new Dictionary<BotType, int>() { { BotType.None, 1 }, { BotType.Speedster, 1 },  { BotType.Perfectionnist, 1 },  { BotType.Aimless, 1 },  { BotType.Introvert, 1 },  { BotType.Lucky, 1 },  { BotType.Persistent, 1 } });
                    break;
                case 2:
                    Turn = new Turn(8, new Dictionary<BotType, int>() { { BotType.None, 2 }, { BotType.Speedster, 2 }, { BotType.Introvert, 1 }, { BotType.Persistent, 1 } });
                    break;
                case 3:
                    Turn = new Turn(8, new Dictionary<BotType, int>() { { BotType.None, 2 }, { BotType.Perfectionnist, 2 }, { BotType.Lucky, 2 } });
                    break;
                case 4:
                    Turn = new Turn(8, new Dictionary<BotType, int>() { { BotType.None, 2 }, { BotType.Aimless, 3 }, { BotType.Persistent, 2 } });
                    break;
                case 5:
                    Turn = new Turn(8, new Dictionary<BotType, int>() { { BotType.None, 2 }, { BotType.Introvert, 2 }, { BotType.Speedster, 1 }, { BotType.Perfectionnist, 1 } });
                    break;
                case 6:
                    Turn = new Turn(10, new Dictionary<BotType, int>() { { BotType.Speedster, 1 }, { BotType.Perfectionnist, 1 },  { BotType.Aimless, 1 },  { BotType.Introvert, 1 },  { BotType.Lucky, 1 },  { BotType.Persistent, 1 } });
                    break;
                default:
                    break;
            }
        }
    }
}