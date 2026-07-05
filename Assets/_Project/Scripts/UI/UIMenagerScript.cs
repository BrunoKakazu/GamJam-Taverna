using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMenagerScript : MonoBehaviour
{
    private PlayerScript player;
    public Slider playerHealthBar;
    public Gradient playerGradient;
    public Image fill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPlayerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPlayerHealth();
    }

    private void DisplayPlayerHealth()
    {
        playerHealthBar.value = player.currenthealth;
        fill.color = playerGradient.Evaluate(playerHealthBar.normalizedValue); // Retorna o valor da vida em forma de porcenagem (0.1 - 1.0)
    }

    private void SetPlayerDisplay()
    {
        player = FindObjectsByType<PlayerScript>(FindObjectsSortMode.None)[0];
        playerHealthBar.maxValue = player.maxHealth;
        fill.color = playerGradient.Evaluate(1f);
    }
}
