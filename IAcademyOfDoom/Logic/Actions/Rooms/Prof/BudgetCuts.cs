using System.Collections.Generic;
using IAcademyOfDoom.Logic.Places;

namespace IAcademyOfDoom.Logic.Actions.Rooms.Prof
{
    public class BudgetCuts : AbstractProfRoomsAction
    {
        public const int Amount = 1;
        
        private readonly Game game;
        
        public BudgetCuts(string name, List<ProfRoom> profRooms, Game game) : base(name, profRooms)
        {
            this.game = game;
        }

        public override void Execute()
        {
            ProfRooms.ForEach(room =>
            {
                int toLose = (room.HP + 1) / 2;
                ChangeProfHp(room, -toLose);
                game.AddMoney(toLose);
            });
        }
    }
}
