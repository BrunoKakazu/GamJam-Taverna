using System;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class CardScript : MonoBehaviour
{
    [SerializeField] public CardData cardData;

    public GameObject image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image.GetComponent<Image>().sprite = cardData.cardSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
