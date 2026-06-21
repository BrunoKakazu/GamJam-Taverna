using System.Collections.Generic;
using UnityEngine;

public class CriarCartas : MonoBehaviour
{
    public static CriarCartas Instance { get; set; }

    [Header("Dados da carta")]
    [SerializeField] private GameObject prefabCarta;
    [SerializeField] private ValoresCartas valores;

    [Header("Referência dos dados")]
    [SerializeField] private List<CardData> cartasData;

    private void Start()
    {
        GameObject carta;
        carta = CriarCarta(0);
        Instantiate(carta);
    }

    // Criação da carta
    public GameObject CriarCarta(int index)
    {
        GameObject carta;

        valores.SetId(cartasData[index].cardName);
        valores.SetValue(cartasData[index].value);
        valores.SetIsAce(cartasData[index].isAce);

        carta = Instantiate(prefabCarta);

        return carta;
    }
}
