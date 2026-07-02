using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class GameMenagerScript : MonoBehaviour
{
    private DeckScript deckScript;
    [SerializeField] private GameObject playerHandArea;
    [SerializeField] private GameObject enemyHandArea;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cardBackPrefab;
    [SerializeField] private TextMeshProUGUI playerHandValue;
    [SerializeField] private List<CardData> playerHand;
    [SerializeField] private List<CardData> enemyHand;
    private int playerHandSize = 0;
    private int enemyHandSize = 0;
    private bool isGameStarted = false;
    private bool isRevealed = false;


    void Start()
    {
        deckScript = FindObjectsByType<DeckScript>(FindObjectsSortMode.None)[0];
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GiveHands();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            RevealCards();
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
            GameObject cardObject = Instantiate(playerHand[playerHandSize].prefab, playerHandArea.transform);
            cardObject.GetComponent<CardScript>().CreateCard(playerHand[playerHandSize]);
            playerHandSize++;
        }
        else // executa o loop para dar a mao inicial (para q a primeira carta sempre fique virada para baixo)
        {
            for (int i = 0; i < 2; i++)
            {
                playerHand.Add(deckScript.GiveCardData());
            
                GameObject cardObject = Instantiate(playerHand[i].prefab, playerHandArea.transform);
                cardObject.GetComponent<CardScript>().CreateCard(playerHand[i]);
                if (i == 0)
                    cardObject.GetComponent<CardScript>().CardFlip();
                playerHandSize++;
            }
        }

    }
    public void GiveEnemyCard(){
        if (isGameStarted) // executa essa parte so depois da mao inicial ter sido distribuida
        {
            enemyHand.Add(deckScript.GiveCardData());
            GameObject cardObject = Instantiate(enemyHand[enemyHandSize].prefab, enemyHandArea.transform);
            cardObject.GetComponent<CardScript>().CreateCard(enemyHand[enemyHandSize]);
            enemyHandSize++;
        }
        else // executa o loop para dar a mao inicial (para q a primeira carta sempre fique virada para baixo)
        {
            for (int i = 0; i < 2; i++)
            {
                enemyHand.Add(deckScript.GiveCardData());

                GameObject cardObject = Instantiate(enemyHand[i].prefab, enemyHandArea.transform);
                cardObject.GetComponent<CardScript>().CreateCard(enemyHand[i]);
                if (i == 0)
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

    void RevealCards()
    {
        enemyHandArea.transform.GetChild(0).gameObject.GetComponent<CardScript>().CardFlip();
        playerHandArea.transform.GetChild(0).gameObject.GetComponent<CardScript>().CardFlip();
        isRevealed = true;

    }

}