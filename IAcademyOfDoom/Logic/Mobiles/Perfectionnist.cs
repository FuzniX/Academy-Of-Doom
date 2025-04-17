using System;
using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.Logic.Mobiles
{
    public class Perfectionnist : Botling
    {
        private bool wasSuccessful = true;

        public Perfectionnist() : base(BotType.Perfectionnist) {}
        
        public override bool GetLessonIn(SkillType skill)
        {
            wasSuccessful = base.GetLessonIn(skill);
            return wasSuccessful;
        }

        protected override (int x, int y) Next(List<Room> rooms, List<Direction> directions = null)
        {
            bool successful = wasSuccessful;
            wasSuccessful = true;
            return successful ? base.Next(rooms, directions) : (X, Y);
        }
    }
}