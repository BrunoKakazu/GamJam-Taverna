using System;
using UnityEngine.UI;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    [SerializeField] private CardData cardData;
    private Image image;
    private DeckScript deckScript;
    [SerializeField] private bool isFliped = false;
    [SerializeField] private AnimationMenagerScript animMenagerScript;
    void Awake()
    {
        deckScript = FindObjectsByType<DeckScript>(FindObjectsSortMode.None)[0];
        animMenagerScript = FindObjectsByType<AnimationMenagerScript>(FindObjectsSortMode.None)[0];
        image = GetComponent<Image>();
    }

    public void CardFlip() // Metodo para flipar a carta
    {
        if (!isFliped)
        {
            animMenagerScript.FlipAnimation(this.gameObject, deckScript.cardBack, false);
            isFliped = true;
        }
        else
        {
            animMenagerScript.FlipAnimation(this.gameObject, cardData.cardSprite, false);
            isFliped = false;
        }
    }
    public void CardFlip(bool hasToAnimate) // Metodo para flipar a carta com animação
    {
        if (!isFliped)
        {
            animMenagerScript.FlipAnimation(this.gameObject, deckScript.cardBack, hasToAnimate);
            isFliped = true;
        }
        else
        {
            animMenagerScript.FlipAnimation(this.gameObject, cardData.cardSprite, hasToAnimate);
            isFliped = false;
        }
    }
    public void CreateCard(CardData cardData) // Metodo para "criar a carta" 
    {
        this.cardData = cardData;
        image.sprite = cardData.cardSprite;
        //Debug.Log($"Carta {cardData.cardID} criada");
    }

}
