using IAcademyOfDoom.Logic.GameSettings;
using IAcademyOfDoom.Logic.Skills;
using System;
using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Mobiles
{
    /// <summary>
    /// A class representing one logical botling mobile.
    /// </summary>
    public class Botling
    {
        /// <summary>
        /// The current values for each basic skill.
        /// </summary>
        public Dictionary<SkillType, int> Skills { get; } = new Dictionary<SkillType, int>();

        /// <summary>
        /// For each combo skill, true iff the bot has earned a badge for this skill.
        /// </summary>
        public Dictionary<SkillType, bool> Badges { get; } = new Dictionary<SkillType, bool>();

        /// <summary>
        /// The botling's hit points, 0 or less: exhausted.
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// A printable name for the botling.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The botling's type.
        /// </summary>
        public BotType Type { get; private set; } = BotType.None;

        /// <summary>
        /// Current column.
        /// </summary>
        public int X { get; set; } = 0;

        /// <summary>
        /// Current row.
        /// </summary>
        public int Y { get; set; } = 0;

        /// <summary>
        /// Whether the botling is guided
        /// </summary>
        public bool Orientation { get; set; } = false;

        /// <summary>
        /// This botling will move there next.
        /// </summary>
        public (int x, int y) NextMove { get; internal set; }

        /// <summary>
        /// Empty constructor, use with caution.
        /// </summary>
        public Botling()
        {
            NextMove = Next(null);
        }

        /// <summary>
        /// Parametered constructor.
        /// </summary>
        /// <param name="type">the type of the botling</param>
        public Botling(BotType type) : this()
        {
            Type = type;
            Name = Names.Next();
            SetInitialSetOfSkills();
            HP = Default.BaseHitPoints(Game.Difficulty);
        }

        /// <summary>
        /// Enact the move.
        /// </summary>
        public void Move(List<Room> rooms)
        {
            (X, Y) = NextMove;
            NextMove = Next(rooms);
        }

        /// <summary>
        /// A diceroll-based test for a skill.
        /// </summary>
        /// <param name="skill">the skill to test (basic or combo)</param>
        /// <param name="difficulty">the level needed to pass</param>
        /// <returns></returns>
        public virtual bool TestSkill(SkillType skill, int difficulty, int diceRoll)
        {
            if (HP <= 0)
            {
                return false;
            }

            if (skill.IsBaseSkill())
            {
                return Skills[skill] + diceRoll > difficulty;
            }
            else
            {
                if (Badges[skill])
                {
                    return true;
                }
                else
                {
                    (SkillType s1, SkillType s2) = skill.BasePair().Value;
                    return Skills[s1] + Skills[s2] + diceRoll > difficulty;
                }
            }
        }

        public int DiceRoll()
        {
            Random random = Game.Random;
            return random.Next(0, Default.DieSize) + 1;
        }

        /// <summary>
        /// Conduct a lesson for the bot in some skill.
        /// </summary>
        /// <param name="skill">the skill, basic or combo</param>
        /// <returns>true iff the lesson is successful</returns>
        public virtual bool GetLessonIn(SkillType skill)
        {
            if (TestSkill(skill, Default.LessonDifficulty(Game.Difficulty, skill.IsBaseSkill() ? 1 : 2), DiceRoll()))
            {
                if (skill.IsBaseSkill())
                {
                    Skills[skill] += Default.TutorReward;
                }
                else
                {
                    (SkillType s1, SkillType s2) = skill.BasePair().Value;
                    Skills[s1]++;
                    Skills[s2]++;
                    Badges[skill] = true;
                }

                return true;
            }
            else
            {
                if (skill.IsBaseSkill())
                {
                    Skills[skill]++;
                    HP--;
                }
                else
                {
                    (SkillType s1, SkillType s2) = skill.BasePair().Value;
                    Skills[s1]++;
                    Skills[s2]++;
                    HP -= 2;
                }

                return false;
            }
        }

        /// <summary>
        /// Performs the final exam.
        /// </summary>
        /// <returns>the exam result</returns>
        public virtual ExamResult Exam()
        {
            List<SkillType> subjects = SkillTypeUtils.AllCombinatedSkills();
            SkillType examinated = subjects[Game.Random.Next(0, subjects.Count)];
            return TestSkill(examinated, Default.ExamDifficulty(Game.Difficulty), DiceRoll())
                ? ExamResult.Success
                : ExamResult.Failure;
        }

        private void SetInitialSetOfSkills()
        {
            int distribute = Default.SkillPoints;
            int max = Default.MaxSkillLevel;
            Random random = Game.Random;
            List<SkillType> skillTypes = SkillTypeUtils.AllBaseSkills();
            int[] ints = new int[skillTypes.Count];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = 0;
            }

            while (distribute > 0)
            {
                int i = 0;
                while (i < skillTypes.Count && distribute > 0)
                {
                    if (random.Next() % 2 == 0 && ints[i] < max)
                    {
                        ints[i]++;
                        distribute--;
                    }

                    i++;
                }
            }

            int j = 0;
            foreach (SkillType skill in skillTypes)
            {
                Skills.Add(skill, ints[j++]);
            }

            foreach (SkillType skill in SkillTypeUtils.AllCombinatedSkills())
            {
                Badges.Add(skill, false);
            }
        }

        /// <summary>
        /// Retrieve botling's next move
        /// </summary>
        /// <param name="rooms"></param>
        /// <param name="directions"></param>
        /// <returns></returns>
        public virtual (int x, int y) Next(List<Room> rooms, List<Direction> directions = null)
        {
            return Next(BestDirection(rooms, directions));
        }

        protected (int x, int y) Next(Direction direction, int length = 1)
        {
            return (AddX(direction, length), AddY(direction, length));
        }

        protected Direction BestDirection(List<Room> rooms, List<Direction> directions)
        {
            if (directions == null) directions = new List<Direction> { Direction.Down, Direction.Right };

            if (X == Game.MaxX) directions.Remove(Direction.Right);
            if (X == 0) directions.Remove(Direction.Left);
            if (Y == Game.MaxY) directions.Remove(Direction.Down);
            if (Y == 0) directions.Remove(Direction.Up);

            if (directions.Count == 0) return Direction.None;

            if (rooms != null && Orientation)
            {
                int offset = 0;
                while (directions.Count > 1 && (offset < Default.Lines || offset < Default.Columns))
                {
                    offset++;
                    Direction bestRoom = BestDirectionAt(offset, rooms, directions);
                    if (bestRoom == Direction.Equivalent) break; // Reaching this line means both skills are equivalent, head to random
                    if (bestRoom == Direction.None) continue;
                    directions = new List<Direction> { bestRoom };
                }
            }
            
            // Choose one among all remaining directions
            return directions[Game.Random.Next() % directions.Count];
        }

        protected Direction BestDirectionAt(int offset, List<Room> rooms, List<Direction> directions)
        {
            Dictionary<Direction, int> skills = new Dictionary<Direction, int>();
            directions.ForEach(direction =>
            {
                if (Game.FindRoomAt(AddX(direction, offset), AddY(direction, offset), rooms) is ProfRoom profRoom)
                {
                    skills.Add(direction, GetMinimumSkill(profRoom.SkillType));
                }
            });
            
            if (skills.Count == 0) return Direction.None;
            KeyValuePair<Direction, int> min = new KeyValuePair<Direction, int>(Direction.None, Int32.MaxValue);
            Dictionary<Direction, int> bestSkills = new Dictionary<Direction, int>();
            foreach (KeyValuePair<Direction, int> pair in skills)
            {
                if (min.Value > pair.Value)
                {
                    min = pair;
                    bestSkills = new Dictionary<Direction, int> {{pair.Key, pair.Value}};
                }
                else if (min.Value == pair.Value) bestSkills.Add(pair.Key, pair.Value);
            }
            return skills.Count == 1 ? min.Key : Direction.Equivalent; 
        }
        
        /// <summary>
        /// Returns the skill value that is the minimum
        /// Consider whether a skill is basic
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private int GetMinimumSkill(SkillType type)
        {
            if (type.IsBaseSkill())
            {
                return Skills[type];
            }
            (SkillType s1, SkillType s2) = type.BasePair().Value;
            return Math.Min(Skills[s1], Skills[s2]);
        }

        private int AddX(Direction direction, int length)
        {
            if (direction == Direction.Left) return X - length;
            if (direction == Direction.Right) return X + length;
            return X;
        }
        
        private int AddY(Direction direction, int length)
        {
            if (direction == Direction.Up) return Y - length;
            if (direction == Direction.Down) return Y + length;
            return Y;
        }
    }
}