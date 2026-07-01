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

        DisplayHandValue();
    }
    public void GiveHands()
    {
        GiveEnemyHand();
        GivePlayerHand();
        isGameStarted = true;
    }
    private void GivePlayerHand()
    {
        if (isGameStarted)
        {
            playerHand.Add(deckScript.GiveCardData());
            GameObject cardObject = Instantiate(playerHand[playerHandSize].prefab, playerHandArea.transform);
            cardObject.GetComponent<CardScript>().CreateCard(playerHand[playerHandSize]);
            playerHandSize++;
        }
        else
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
    private void GiveEnemyHand(){
        if (isGameStarted)
        {
            enemyHand.Add(deckScript.GiveCardData());
            GameObject cardObject = Instantiate(enemyHand[enemyHandSize].prefab, enemyHandArea.transform);
            cardObject.GetComponent<CardScript>().CreateCard(enemyHand[enemyHandSize]);
            enemyHandSize++;
        }
        else
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

        for (int i = 1; i < playerHand.Count; i++)
        {
            displayValue += playerHand[i].value;
        }

        playerHandValue.text = $"Hand value: {displayValue}";
    }

}