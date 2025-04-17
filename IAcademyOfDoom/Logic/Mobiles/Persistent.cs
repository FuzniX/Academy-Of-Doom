namespace IAcademyOfDoom.Logic.Mobiles
{
    public class Persistent : Botling
    {
        public Persistent() : base(BotType.Persistent) {}

        public override ExamResult Exam()
        {
            ExamResult result = base.Exam();
            if (result == ExamResult.Failure) (X, Y) = (0, 0);
            return result;
        }
    }
}