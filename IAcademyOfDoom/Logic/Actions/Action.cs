namespace IAcademyOfDoom.Logic.Actions
{
   
    public abstract class Action
    {
        public const int Amount = 0;
        
        public readonly string Name;

        protected Action(string name) => Name = name;
        
        public abstract void Execute();
    }
}
