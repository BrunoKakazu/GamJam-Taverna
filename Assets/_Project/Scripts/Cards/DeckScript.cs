using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckScript : MonoBehaviour
{
    public List<Sprite> cardSprites;
    public List<CardData> cardDatas;
    int currentIndex = 0;

    void Awake()
    {
        for (int i = 1; i < 40; i++)
        {
            cardDatas.Add(new CardData());
            cardDatas[i].cardID = i;
            cardDatas[i].value = (i % 13) + 1;
            if (cardDatas[i].value == 1)
                cardDatas[i].isAce = true;
            
        }

        currentIndex = 0;
        Shuffle();

    }
    void Start()
    {
        foreach (CardData card in cardDatas)
        {
            Debug.Log(card.cardID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CardData GiveCard()
    {
        if (currentIndex >= cardDatas.Count)
    {
        Debug.LogWarning("Baralho esgotado");
    }
        Debug.Log(currentIndex);
        CardData cardGiven = cardDatas[currentIndex];
        currentIndex++;
        return cardGiven;

    }

    public void Shuffle()
    {
        cardDatas = cardDatas.OrderBy(item => Random.value).ToList();
        currentIndex = 0;
    }
}
