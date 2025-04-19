using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAcademyOfDoom.Logic.Actions
{
   
    public abstract class Action
    {
        public static readonly int Amount = 0;
        
        private readonly string name;

        public Action(string name)
        {
            this.name = name;
        }
        
        public abstract void Execute();
    }
}
