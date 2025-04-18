using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAcademyOfDoom.Logic.Actions
{
    public class RefresherCourse
    {
        public RefresherCourse(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int Y { get; set; }

        public int X { get; set; }
    }
}
