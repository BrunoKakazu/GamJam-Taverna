using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriarCartas : MonoBehaviour
{
    public static CriarCartas Instance { get; set; }

    [Header("Dados da carta")]
    [SerializeField] private GameObject prefabCarta;
    [SerializeField] private ValoresCartas valores;
    [SerializeField] private Sprite versoSprite;

    [Header("Referência dos dados")]
    [SerializeField] private List<CardData> cartasData;

    private void Start()
    {
        // Teste
        //GameObject carta;
        //carta = CriarCarta(0);
        //Instantiate(carta);
    }

    // Criação da carta
    public GameObject CriarCarta(int index)
    {
        GameObject carta;

        // Setagem dos valores
        valores.SetId(cartasData[index].cardID);
        valores.SetValue(cartasData[index].value);
        valores.SetIsAce(cartasData[index].isAce);

        //carta = Instantiate(prefabCarta);
        carta = prefabCarta;
        carta.GetComponentInChildren<Image>().sprite = versoSprite;

        return carta;
    }
}
