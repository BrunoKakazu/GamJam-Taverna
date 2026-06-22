using System;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardScript : MonoBehaviour
{
    [SerializeField] private CardData cardData;

    [SerializeField] private GameObject cardSprite;
    [SerializeField] private DeckScript deckScript;

    private bool isFliped;

    void Awake()
    {
        deckScript = FindObjectsByType<DeckScript>(FindObjectsSortMode.None)[0];
    }

    void Start()
    {   
        cardData = deckScript.GiveCard();
        cardSprite.GetComponent<Image>().sprite = deckScript.cardSprites[cardData.cardID];

        CardFlip();
    }

    void Update()
    {
        
    }

    private void CardFlip()
    {
        if (!isFliped)
        {
            cardSprite.GetComponent<Image>().sprite = deckScript.cardSprites[0];
        }
        else
        {
            cardSprite.GetComponent<Image>().sprite = deckScript.cardSprites[cardData.cardID];
        }
    }


}
