using System;
using UnityEngine.UI;
using UnityEngine;


public class CardScript : MonoBehaviour
{
    [SerializeField] private CardData cardData;
    private Sprite cardSprite;
    private DeckScript deckScript;
    [SerializeField] private bool isFliped = false;

    void Awake()
    {
        deckScript = FindObjectsByType<DeckScript>(FindObjectsSortMode.None)[0];
        cardSprite = gameObject.GetComponent<Image>().sprite;
        CreateCard();
    }
    void Update()
    {
        //CardFlip();
    }
    private void CardFlip() // Metodo para flipar a carta
    {
        if (isFliped)
            cardSprite = deckScript.cardBack;
        else
            cardSprite = deckScript.cardSprites[cardData.cardID];
    }
    public void CreateCard() // Metodo para "criar a carta" 
    {
        cardData = deckScript.GiveCard(); // Da todas as informaçoes da carta
        cardSprite = cardData.cardSprite;
    }
    public void CreateCard(CardData cardData) // Metodo para "criar a carta" 
    {
        cardData = deckScript.GiveCard(); // Da todas as informaçoes da carta
        cardSprite = cardData.cardSprite;

    }
}
