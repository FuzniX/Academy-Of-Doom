using IAcademyOfDoom.Logic.Actions;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.Logic.Places
{
    public class PlaceableAction
    {
        public readonly string Name;
        
        public SkillType? Skill { get; set; }
        public ActionType ActionType { get; private set; }
        
        public PlaceableAction(ActionType actionType, string name, SkillType? skill = null)
        {
            this.ActionType = actionType;
            this.Name = name;
            this.Skill = skill;
        }

        /// <summary>
        /// ToString override for displaying info.
        /// </summary>
        /// <returns>a full representation</returns>
        public override string ToString()
        {
            if (Name == null)
            {
                return "Action : " + ActionType.ToString() + "-" + Skill?.ToString() + "; ";
            }
            return Name;
        }
    }
}