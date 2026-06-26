using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckScript : MonoBehaviour
{
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

    public CardData GiveCard()
    {
        if (currentIndex >= cardDatas.Count)
        {
            Debug.LogWarning("Baralho esgotado");
        }
        //Debug.Log(currentIndex);
        CardData cardGiven = cardDatas[currentIndex];
        currentIndex++;
        return cardGiven;
    }

    public void CreateDeck()
    {
        for (int i = 13; i < 52; i++)
        {
            cardDatas.Add(ScriptableObject.CreateInstance<CardData>());
            cardDatas[i].cardID = i;
            cardDatas[i].value = (i % 10) + 1;
            cardDatas[i].cardSprite = cardSprites[cardDatas[i].cardID];
            if (cardDatas[i].value == 1)
                cardDatas[i].isAce = true;
            
        }
        
    }

    public void Shuffle()
    {
        cardDatas = cardDatas.OrderBy(item => Random.value).ToList();
        currentIndex = 0;
    }
}
