using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMenagerScript : MonoBehaviour
{
    [Header ("Player health bar: ")]
    private PlayerScript player;
    public Slider playerHealthBar;
    public Gradient playerGradient;
    public Image playerFill;

    [Header("Enemy health bar: ")]
    private EnemyScript enemy;
    public Slider enemyHealthBar;
    public Gradient enemyGradient;
    public Image enemyFill;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetEnemyDisplay();
        SetPlayerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPlayerHealth();
        DisplayEnemyHealth();
    }

    private void DisplayPlayerHealth()
    {
        playerHealthBar.value = player.currenthealth;
        playerFill.color = playerGradient.Evaluate(playerHealthBar.normalizedValue); // Retorna o valor da vida em forma de porcenagem (0.1 - 1.0)
    }

    private void DisplayEnemyHealth()
    {
        enemyHealthBar.value = enemy.currenthealth;
        enemyFill.color = enemyGradient.Evaluate(enemyHealthBar.normalizedValue);
    }

    private void SetPlayerDisplay()
    {
        player = FindObjectsByType<PlayerScript>(FindObjectsSortMode.None)[0];
        playerHealthBar.maxValue = player.maxHealth;
        playerFill.color = playerGradient.Evaluate(1f);
    }

    private void SetEnemyDisplay()
    {
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None)[0];
        enemyHealthBar.maxValue = enemy.maxHealth;
        enemyFill.color = enemyGradient.Evaluate(1f);
    }
}
