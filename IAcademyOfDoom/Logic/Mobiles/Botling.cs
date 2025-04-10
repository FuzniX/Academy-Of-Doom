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
        public (int x, int y) NextMove { get; private set; }

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
        public bool TestSkill(SkillType skill, int difficulty)
        {
            if (HP <= 0)
            {
                return false;
            }

            Random random = Game.Random;
            if (skill.IsBaseSkill())
            {
                return Skills[skill] + random.Next(0, Default.DieSize) + 1 > difficulty;
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
                    return Skills[s1] + Skills[s2] + random.Next(0, Default.DieSize) + 1 > difficulty;
                }
            }
        }

        /// <summary>
        /// Conduct a lesson for the bot in some skill.
        /// </summary>
        /// <param name="skill">the skill, basic or combo</param>
        /// <returns>true iff the lesson is successful</returns>
        public bool GetLessonIn(SkillType skill)
        {
            if (TestSkill(skill, Default.LessonDifficulty(Game.Difficulty, skill.IsBaseSkill() ? 1 : 2)))
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
        public ExamResult Exam()
        {
            List<SkillType> subjects = SkillTypeUtils.AllCombinatedSkills();
            SkillType examinated = subjects[Game.Random.Next(0, subjects.Count)];
            return TestSkill(examinated, Default.ExamDifficulty(Game.Difficulty))
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
        /// <returns></returns>
        private (int x, int y) Next(List<Room> rooms)
        {
            if (X == Game.MaxX && Y == Game.MaxY)
            {
                return (X, Y);
            }

            if (X == Game.MaxX)
            {
                return (X, Y + 1);
            }

            if (Y == Game.MaxY)
            {
                return (X + 1, Y);
            }

            if (rooms != null && Orientation)
            {
                int offset = 0;
                Room roomX;
                Room roomY;
                while (X + offset < Game.MaxX && Y + offset < Game.MaxY)
                {
                    roomX = Game.FindRoomAt(X + offset, Y, rooms);
                    roomY = Game.FindRoomAt(X, Y + offset, rooms);
                        
                    if (roomX != null && roomY != null)
                    {
                        // Process of choosing the best room
                        
                        // Initialize skills points, defined as if rooms are not prof rooms
                        int skillX = -1;
                        int skillY = -1;
                        
                        if (roomX is ProfRoom profRoomX)
                        {
                            skillX = GetMinimumSkill(profRoomX.SkillType);
                        }

                        if (roomY is ProfRoom profRoomY)
                        {
                            skillY = GetMinimumSkill(profRoomY.SkillType);
                        }
                        
                        // Check that both rooms are prof rooms
                        if (skillX != -1 && skillY != -1) // skillX + skillX != -2 would have worked too
                        {
                            if (skillX < skillY)
                            {
                                return (X + 1, Y);
                            }

                            if (skillX > skillY)
                            {
                                return (X, Y + 1);
                            }
                            // Reaching this line means both skills are equivalent, head to random
                        }
                    }

                    if (roomX != null)
                    {
                        return (X + 1, Y);
                    }

                    if (roomY != null)
                    {
                        return (X, Y + 1);
                    }

                    offset++;
                }
            }

            // We get here either if:
            // - no rooms were passed (constructor)
            // - there is no room in both directions
            // - rooms in both directions are equivalent
            if (Game.Random.Next() % 2 == 0)
            {
                return (X, Y + 1);
            }

            return (X + 1, Y);
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
    }
}