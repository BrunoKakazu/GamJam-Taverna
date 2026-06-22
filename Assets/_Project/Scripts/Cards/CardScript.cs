using System;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardScript : MonoBehaviour
{
    [SerializeField] private CardData cardData;

    public GameObject cardSprite;
    public DeckScript deck;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardData = deck.GiveCard();
        //Debug.Log(cardData.value);
        cardSprite.GetComponent<Image>().sprite = deck.cardSprites[cardData.cardID];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
