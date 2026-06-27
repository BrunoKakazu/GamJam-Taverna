using System;
using UnityEngine.UI;
using UnityEngine;


public class CardScript : MonoBehaviour
{
    [SerializeField] private CardData cardData;
    private Image image;
    private DeckScript deckScript;
    [SerializeField] private bool isFliped = false;

    void Awake()
    {
        deckScript = FindObjectsByType<DeckScript>(FindObjectsSortMode.None)[0];
        image = GetComponent<Image>();
    }
    void Update()
    {

    }
    public void CardFlip() // Metodo para flipar a carta
    {
        if (isFliped)
            image.sprite = deckScript.cardBack;
        else
            image.sprite = cardData.cardSprite;
    }
    public void CreateCard(CardData cardData) // Metodo para "criar a carta" 
    {
        this.cardData = cardData;
        image.sprite = cardData.cardSprite;
    }

}
