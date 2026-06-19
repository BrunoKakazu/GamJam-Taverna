using UnityEngine;

[System.Serializable]
public class DoubleEffect : ICardEffect
{
    public void Apply(BattleContext ctx) => ctx.damageMultiplier *= 2f;
}
