using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameMenagerScript : MonoBehaviour
{
    private DeckScript deckScript;
    [SerializeField] private GameObject playerHandArea;
    [SerializeField] private GameObject enemyHandArea;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cardBackPrefab;
    [SerializeField] private List<CardData> playerHand;
    [SerializeField] private List<CardData> enemyHand;
    private int handSize = 2;

    private CardScript cardScript;

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
    }

    public void GiveHands()
    {
        GiveEnemyHand();
        GivePlayerHand();        
    }

    private void GivePlayerHand()
    {
        for (int i = 0; i < handSize; i++)
        {
            playerHand.Add(deckScript.GiveCardData());
        }
        for (int i = 0; i < handSize; i++)
        {
            GameObject cardObject = Instantiate(playerHand[i].prefab, playerHandArea.transform);
            cardObject.GetComponent<CardScript>().CreateCard(playerHand[i]);
        }
    }
    private void GiveEnemyHand(){

        for (int i = 0; i < handSize; i++)
        {
            enemyHand.Add(deckScript.GiveCardData());
        }

        for(int i = 0; i < handSize; i++)
        {
            Instantiate(cardBackPrefab, enemyHandArea.transform);
        }
    }

}