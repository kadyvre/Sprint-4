namespace Project_TARDIS
{
    /// <summary>
    /// traveler battle action choices
    /// </summary>
    public enum BattleAction
    {
        None,
        Attack,
        Retreat
    }

    /// <summary>
    /// possible battle results
    /// </summary>
    public enum BattleResult
    {
        None,
        TravelerWins,
        NPCWins,
        TravelerRetreats,
        NPCRetreats,
        Draw,
        BothRetreat
    }
}
