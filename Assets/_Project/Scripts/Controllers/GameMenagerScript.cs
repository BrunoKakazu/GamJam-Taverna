using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameMenagerScript : MonoBehaviour
{
    [Header("Hand areas: ")]
    [SerializeField] private GameObject playerHandArea;
    [SerializeField] private GameObject enemyHandArea;
    [SerializeField] private Transform deck;

    [Header("Hand cards: ")]
    [SerializeField] private List<CardData> playerHand;
    [SerializeField] private List<CardData> enemyHand;
    private int playerHandSize = 0;
    private int enemyHandSize = 0;

    [Header("Card sprites: ")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cardBackPrefab;

    [SerializeField] private TextMeshProUGUI playerHandValue;
    private DeckScript deckScript;

    [SerializeField] private AnimationMenagerScript animScript;

    private bool isGameStarted = false;

    private bool isRevealed = false;


    void Start()
    {
        deckScript = FindObjectsByType<DeckScript>(FindObjectsSortMode.None)[0];
    }
    void Update()
    {
        if (!isGameStarted)
        {
            GiveHands();
        }

        DisplayHandValue();
    }
    public void GiveHands() 
    {
        GiveEnemyCard();
        GivePlayerCard();
        isGameStarted = true; // depois da primeira mao ser distribuida, o jogo começa oficialmente
    }
    public void GivePlayerCard()
    {
        if (isGameStarted) // executa essa parte so depois da mao inicial ter sido distribuida
        {
            playerHand.Add(deckScript.GiveCardData());
            GameObject cardObject = Instantiate(playerHand[playerHandSize].prefab, deck);
            cardObject.GetComponent<CardScript>().CreateCard(playerHand[playerHandSize]);
            cardObject.GetComponent<CardScript>().CardFlip();
            animScript.SpawnAnimation(cardObject, playerHandArea.transform); // Faz a animaçao da carta indo até a mão
            playerHandSize++;
        }
        else // executa o loop para dar a mao inicial (para q a primeira carta sempre fique virada para baixo)
        {
            for (int i = 0; i < 2; i++)
            {
                playerHand.Add(deckScript.GiveCardData());
                GameObject cardObject = Instantiate(playerHand[i].prefab, deck);
                cardObject.GetComponent<CardScript>().CreateCard(playerHand[i]);
                animScript.SpawnAnimation(cardObject, playerHandArea.transform); // Faz a animaçao da carta indo até a mão
                if (i != 0)
                    cardObject.GetComponent<CardScript>().CardFlip();
                playerHandSize++;
            }
        }

    }
    public void GiveEnemyCard(){
        if (isGameStarted) // executa essa parte so depois da mao inicial ter sido distribuida
        {
            enemyHand.Add(deckScript.GiveCardData());
            GameObject cardObject = Instantiate(enemyHand[enemyHandSize].prefab, deck);
            cardObject.GetComponent<CardScript>().CreateCard(enemyHand[enemyHandSize]);
            cardObject.GetComponent<CardScript>().CardFlip();
            animScript.SpawnAnimation(cardObject, enemyHandArea.transform); // Faz a animaçao da carta indo até a mão
            enemyHandSize++;
        }
        else // executa o loop para dar a mao inicial (para q a primeira carta sempre fique virada para baixo)
        {
            for (int i = 0; i < 2; i++)
            {
                enemyHand.Add(deckScript.GiveCardData());
                GameObject cardObject = Instantiate(enemyHand[i].prefab, deck);
                cardObject.GetComponent<CardScript>().CreateCard(enemyHand[i]);
                animScript.SpawnAnimation(cardObject, enemyHandArea.transform);
                if (i != 0)
                    cardObject.GetComponent<CardScript>().CardFlip();
                enemyHandSize++;
            }
        }

    }
    private void DisplayHandValue()
    {
        int displayValue = 0;
        int index = 1;

        if (isRevealed)
        {
            index = 0;
        }

        for (int i = index; i < playerHand.Count; i++)
        {
            if (playerHand[i].isAce && displayValue < 21)
            {
                displayValue += 10;
            }
            displayValue += playerHand[i].value;
        }

        if (displayValue <= 21)
            playerHandValue.text = $"Hand value: {displayValue}";
        else
        {
            playerHandValue.text = $"Hand value: {displayValue}";
            playerHandValue.color = Color.red;

        }
    }
    public void RevealCards()
    {
        enemyHandArea.transform.GetChild(0).gameObject.GetComponent<CardScript>().CardFlip(true);
        playerHandArea.transform.GetChild(0).gameObject.GetComponent<CardScript>().CardFlip(true);
        isRevealed = true;
    }
    public int GetPlayerDamage()
    {
        int damage = 0;
        for (int i = 0; i < playerHand.Count; ++i)
        {
            if (playerHand[i].isAce && damage < 21)
            {
                damage += 11;
            }
            damage += playerHand[i].value;
        }
        return damage;
    }
    public int GetEnemyDamage()
    {
        int damage = 0;
        for (int i = 0; i < enemyHand.Count; ++i)
        {
            damage += enemyHand[i].value;
        }
        return damage;
    }
}