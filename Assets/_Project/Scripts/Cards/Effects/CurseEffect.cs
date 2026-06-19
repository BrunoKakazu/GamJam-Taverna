using UnityEngine;

[System.Serializable]
public class CurseEffect : ICardEffect
{
    public int reductionAmount = 10;
    public void Apply(BattleContext ctx) => ctx.curseDamageReduction = reductionAmount;
}
