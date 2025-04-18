using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions
{
    public class PremisesRenovation
    {
        public ProfRoom ProfRoom { get; set; }
        
        public PremisesRenovation(ProfRoom profRoom)
        {
            this.ProfRoom = profRoom;
        }

        
    }
}
