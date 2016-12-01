using System;

namespace Project_TARDIS
{
    public class Dalek : Character, IBattle
    {
        public bool HasMessage { get; set; }
        public string Message { get; set; }
        public int Health { get; set; }
        public int Lives { get; set; }

        //
        // a value 0-100 determines how often the Dalek 
        // chooses attack over retreat
        //
        public int AggressionIndex { get; set; }

        //
        // a value 0-100 determines the Dalek's
        // battle ability
        //
        public int BattleIndex { get; set; }

        public BattleAction GetBattleAction()
        {
            BattleAction battleAction = BattleAction.None;

            Random random = new Random();

            if (random.Next(1, 100) < this.AggressionIndex)
            {
                battleAction = BattleAction.Attack;
            }
            else
            {
                battleAction = BattleAction.Retreat;
            }

            return battleAction;
        }
    }
}
