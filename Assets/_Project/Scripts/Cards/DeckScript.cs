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
            CardData card = ScriptableObject.CreateInstance<CardData>();
            card.cardID = i;
            card.value = (i % 10) + 1;
            card.cardSprite = cardSprites[i];
            card.prefab = cardPrefab;
            card.isAce = card.value == 1;
            cardDatas.Add(card);
            /*
            cardDatas[i].cardID = i;
            cardDatas[i].value = (i % 10) + 1;
            cardDatas[i].cardSprite = cardSprites[cardDatas[i].cardID];
            cardDatas[i].prefab = cardPrefab; 
            if (cardDatas[i].value % 10 == 0)
                cardDatas[i].isAce = true;
            */
        }
        currentIndex = 0;
    }

    public void Shuffle()
    {
        cardDatas = cardDatas.OrderBy(item => Random.value).ToList();
        currentIndex = 0;
    }
}
