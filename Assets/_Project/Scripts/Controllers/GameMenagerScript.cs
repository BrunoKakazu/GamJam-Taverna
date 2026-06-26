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
    [SerializeField] private List<CardData> playerHand;
    [SerializeField] private List<CardData> enemyHand;
    private int handSize = 2;

    void Start()
    {
        deckScript = FindObjectsByType<DeckScript>(FindObjectsSortMode.None)[0];

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GiveHands();
        }
    }

    public void GiveHands()
    {
        for (int i = 0; i < handSize; i++)
        {
            playerHand.Add(deckScript.GiveCard());
            enemyHand.Add(deckScript.GiveCard());
        }

        Instantiate(cardPrefab);

        for(int i = 0; i < handSize; i++)
        {
            Instantiate(playerHand[i], playerHandArea.transform);
            Instantiate(enemyHand[i], enemyHandArea.transform);
            
        }
        
    }
}
