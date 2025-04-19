namespace IAcademyOfDoom.Logic.Actions
{
   
    public abstract class Action
    {
        public static readonly int Amount = 0;
        
        public readonly string Name;

        protected Action(string name) => Name = name;
        
        public abstract void Execute();
    }
}
