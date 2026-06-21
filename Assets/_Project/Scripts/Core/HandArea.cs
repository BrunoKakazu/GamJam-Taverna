using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandArea : MonoBehaviour
{
    [SerializeField] private GameObject _handPlayer;
    [SerializeField] private List<CardData> _cardsData;
    [SerializeField] private List<GameObject> _cards;

    public GameObject prefabCarta;
    private GameObject mao;

    private void Start()
    {
        //Hand(prefabCarta, 4);
    }

    public void Hand(GameObject card, int quantityCards)
    {
        int quantity = 0;

        while(quantity < quantityCards)
        {

            mao = CriarCartas.Instance.CriarCarta(quantity);

            _cards.Add(mao);

            quantity += 1;
        }

    }
}
