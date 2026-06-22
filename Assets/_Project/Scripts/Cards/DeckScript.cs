using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckScript : MonoBehaviour
{
    public List<Sprite> cardSprites;
    public List<CardData> cardDatas;
    int currentIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public CardData GiveCard()
    {
        if (currentIndex >= cardDatas.Count)
    {
        Debug.LogWarning("Baralho esgotado — embaralhando de novo.");
    }

        CardData cardGiven = cardDatas[currentIndex];
        //Debug.Log(cardGiven.value);
        currentIndex++;
        return cardGiven;

    }

    public void Shuffle()
    {
        cardDatas = cardDatas.OrderBy(item => Random.value).ToList();
        currentIndex = 0;
    }
}
