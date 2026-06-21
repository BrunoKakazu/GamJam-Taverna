using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public List<Sprite> cardSprites;
    public List<CardData> cardDatas;
    [SerializeField] private GameObject cardPrefab;

        public CardData randomGenerate()
    {
        int randI = Random.Range(1, cardDatas.Count);
        return cardDatas[randI];

    }
}
