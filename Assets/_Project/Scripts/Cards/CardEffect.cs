public interface ICardEffect
{
    void Apply(BattleContext ctx); // O BattleContext carrega as infos
}

public class BattleContext
{
    public int playerHandValue;
    public int enemyHandValue;
    public int playerShield;
    public int enemyShield;
    public float damageMultiplier;   // Começa em 1f
    public int bonusDamage;
    public int curseDamageReduction; // Aplicado no turno do oponente
    public bool canDrawExtra;        // Fôlego
    public bool enemyCardRevealed;   // Revelar
    public int playerHP;
    public int enemyHP;
}
