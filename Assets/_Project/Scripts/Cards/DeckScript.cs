using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public List<Sprite> cardSprites;
    public List<CardData> cardDatas;
    [SerializeField] private GameObject cardPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public CardData randomGenerate()
    {
        int randI = Random.Range(1, cardDatas.Count);
        return cardDatas[randI];

    }
}
