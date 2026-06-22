using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriarCartas : MonoBehaviour
{
    public static CriarCartas Instance { get; set; }

    [Header("Dados da carta")]
    [SerializeField] private GameObject prefabCarta;
    [SerializeField] private ValoresCartas valores;
    [SerializeField] private List<Sprite> cardSprites;
    [SerializeField] private Sprite versoSprite;

    [Header("Referência dos dados")]
    [SerializeField] private List<CardData> cartasData;

    private int contador;

    private void Start()
    {
        // Teste
        //GameObject carta;
        //carta = CriarCarta(0);
        //Instantiate(carta);
        contador = 0;
    }

    // Criação da carta
    public GameObject CriarCarta(int index)
    {
        GameObject carta;
        if (contador == 12)
        {
            contador = 0;
        }
        else
        {
            // Setagem dos valores
            valores.SetId(cartasData[contador].cardID);
            valores.SetValue(cartasData[contador].value);
            valores.SetIsAce(cartasData[contador].isAce);
            contador++;
        }
        
        //carta = Instantiate(prefabCarta);
        // Setando a carta
        carta = prefabCarta;
        carta.name = cardSprites[index].name;
        carta.GetComponent<Image>().sprite = cardSprites[index];
        carta.GetComponentInChildren<ValoresCartas>().GetVerso().GetComponent<Image>().sprite = versoSprite;

        return carta;
    }
}
