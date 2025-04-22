using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAcademyOfDoom.Logic.Mobiles;

namespace IAcademyOfDoom.View
{
    public class ActionView
    {
        public readonly string Name;
        public Action Action { get; set; }

        public ActionView(string name) => Name = name;
    }
}
