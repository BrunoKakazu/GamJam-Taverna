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

    private void CreateDeck()
    {
        for (int i = 0; i < 52; i++)
        {
            CardData card = ScriptableObject.CreateInstance<CardData>();
            card.cardID = i;
            int valueCheck = (i % 13) + 1;
            card.value = valueCheck > 10 ? 10 : valueCheck;
            card.cardSprite = cardSprites[i];
            card.prefab = cardPrefab;
            card.isAce = valueCheck == 1;
            cardDatas.Add(card);

        }
        currentIndex = 0;
    }

    public void Shuffle()
    {
        cardDatas = cardDatas.OrderBy(item => Random.value).ToList();
        currentIndex = 0;
    }
}
