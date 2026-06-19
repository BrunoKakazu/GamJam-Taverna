using UnityEngine;

// REMOVER ANTES DA BUILD FINAL PELO AMOR DE DEUS

public class CardTestes : MonoBehaviour
{
    [Header("Arraste os assets aqui")]
    public EffectCardData[] effectCards;
    public CardData[] commonCards;

    void Start()
    {
        TestCommonCards();
        TestEffectCards();
    }

    void TestCommonCards()
    {
        Debug.Log("CARTAS COMUNS");
        int total = 0;
        foreach (var card in commonCards)
        {
            Debug.Log($"{card.cardName} | valor: {card.value} | ás: {card.isAce}");
            total += card.value;
        }

        Debug.Log($"Soma total do baralho (1 de cada): {total} - esperado: 95");
    }
    void TestEffectCards()
    {
        Debug.Log("CARTAS DE EFEITO");
        foreach (var effectCard in effectCards)
        {
            Debug.Log($"{effectCard.cardName} | timing: {effectCard.timing} | usos: {effectCard.usesPerBattle}");

            // Cria um contexto falso com valores conhecidos
            var ctx = new BattleContext
            {
                playerShield = 0,
                enemyShield = 0,
                damageMultiplier = 1f,
                bonusDamage = 0,
                curseDamageReduction = 0,
                canDrawExtra = false,
                enemyCardRevealed = false,
                playerHP = 100,
                enemyHP = 60,
            };

            effectCard.effect.Apply(ctx);
            LogContext(effectCard.cardName, ctx);
        }
    }

    void LogContext(string cardName, BattleContext ctx)
    {
        Debug.Log($"  Resultado de [{cardName}]:\n" +
                  $"  playerShield={ctx.playerShield} | enemyShield={ctx.enemyShield}\n" +
                  $"  damageMultiplier={ctx.damageMultiplier} | bonusDamage={ctx.bonusDamage}\n" +
                  $"  curseDamageReduction={ctx.curseDamageReduction}\n" +
                  $"  canDrawExtra={ctx.canDrawExtra} | enemyCardRevealed={ctx.enemyCardRevealed}\n" +
                  $"  playerHP={ctx.playerHP} | enemyHP={ctx.enemyHP}");
    }
}

