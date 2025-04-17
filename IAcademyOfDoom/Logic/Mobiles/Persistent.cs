﻿using System;
using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Mobiles
{
    public class Persistent : Botling
    {
        private bool HadFailed = false;
        public Persistent() : base(BotType.Persistent) {}

        public override ExamResult Exam()
        {
            ExamResult result = base.Exam();
            HadFailed = result == ExamResult.Failure;
            if (result == ExamResult.Failure) (X, Y) = (0, 0);
            return result;
        }

        public override (int x, int y) Next(List<Room> rooms, List<Direction> directions = null)
        {
            if (HadFailed) {HadFailed = false; return (0, 0);}
            return base.Next(rooms, directions);
        }
    }
}