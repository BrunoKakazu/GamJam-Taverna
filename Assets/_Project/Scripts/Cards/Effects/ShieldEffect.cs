using UnityEngine;

[System.Serializable]
public class ShieldEffect : ICardEffect
{
    public int shieldAmount = 8;
    public void Apply(BattleContext ctx) => ctx.playerShield += shieldAmount;
}