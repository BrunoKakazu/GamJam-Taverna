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
        currentIndex = 0;
        Shuffle();

    }
    void Start()
    {
        Debug.Log(currentIndex);
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
