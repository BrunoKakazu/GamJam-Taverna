using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CriarBaralho : MonoBehaviour
{
    private const int MAXIMODECARTAS = 52;

    [SerializeField] private CriarCartas criarCartas;
    [SerializeField] private List<Sprite> cardSprites;

    public List<GameObject> baralho;

    private void Start()
    {
        baralho = IniciarBaralho();
    }

    private List<GameObject> IniciarBaralho()
    {
        List<GameObject> baralhoInicial = new List<GameObject>();
        GameObject carta;
        int contador = 0;

        for (int i = 0; i < MAXIMODECARTAS; i++)
        {
            if (contador > 12)
            {
                contador = 0;
            }
            Debug.Log($"Contador = {contador} e i = {i}");
            carta = criarCartas.CriarCarta(contador);
            carta.GetComponent<Image>().sprite = cardSprites[i];
            baralhoInicial.Add(carta);
            contador++;
            Debug.Log($"Quantidade de cartas no baralho = {baralhoInicial.Count}");
        }

        Debug.Log($"Quantidade de cartas no baralho = {baralhoInicial.Count}");
        baralhoInicial = Embaralhar(baralhoInicial);

        return baralhoInicial;
    }

    private List<GameObject> Embaralhar(List<GameObject> baralho)
    {
        baralho = baralho.OrderBy(item => Random.value).ToList();

        return baralho;
    }
}
