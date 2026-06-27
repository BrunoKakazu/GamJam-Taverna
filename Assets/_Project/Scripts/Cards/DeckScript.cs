using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckScript : MonoBehaviour
{
    public GameObject cardPrefab;
    public Sprite cardBack;
    public List<Sprite> cardSprites;
    public List<CardData> cardDatas;
    int currentIndex = 0;

    void Awake()
    {
        CreateDeck();
        currentIndex = 0;
        Shuffle();
    }

    public CardData GiveCardData()
    {
        if (currentIndex >= cardDatas.Count)
        {
            Debug.LogWarning("Baralho esgotado");
        }
        CardData cardGiven = cardDatas[currentIndex];
        currentIndex++;
        Debug.Log(currentIndex);
        return cardGiven;
    }

    public void CreateDeck()
    {
        for (int i = 0; i < 52; i++)
        {
            cardDatas.Add(new CardData());
            cardDatas[i].cardID = i;
            cardDatas[i].value = (i % 10) + 1;
            cardDatas[i].cardSprite = cardSprites[cardDatas[i].cardID];
            cardDatas[i].prefab = cardPrefab; 
            if (cardDatas[i].value % 10 == 0)
                cardDatas[i].isAce = true;
            
        }
        
    }

    public void Shuffle()
    {
        cardDatas = cardDatas.OrderBy(item => Random.value).ToList();
        currentIndex = 0;
    }
}
