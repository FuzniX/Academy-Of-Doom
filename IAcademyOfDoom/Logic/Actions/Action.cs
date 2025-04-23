namespace IAcademyOfDoom.Logic.Actions
{
   
    public abstract class Action
    {
        public readonly string Name;

        protected Action(string name) => Name = name;
        
        public abstract void Execute();
    }
}
