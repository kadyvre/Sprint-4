namespace Project_TARDIS
{
    public interface IBattle
    {
        int Health { get; set; }
        int Lives { get; set; }
        int AggressionIndex { get; set; }
        int BattleIndex { get; set; }
        BattleAction GetBattleAction();
    }
}
