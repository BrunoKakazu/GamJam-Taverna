using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CriarBaralho : MonoBehaviour
{
    private const int MAXIMODECARTAS = 52;

    [SerializeField] private CriarCartas criarCartas;
    [SerializeField] private Transform localBaralho;

    public List<GameObject> baralho;

    private void Start()
    {
        IniciarBaralho(baralho);
    }

    //private List<GameObject> IniciarBaralho()
    //{
    //    List<GameObject> baralhoInicial = new List<GameObject>();
    //    GameObject carta;
    //    int contador = 0;

    //    for (int i = 0; i < MAXIMODECARTAS; i++)
    //    {
    //        if (contador > 12)
    //        {
    //            contador = 0;
    //        }
    //        carta = criarCartas.CriarCarta(contador);
    //        carta.GetComponent<Image>().sprite = cardSprites[i];
    //        Debug.Log($"Nome do sprite: {cardSprites[i].name}");
    //        Debug.Log($"Nome do sprite sendo guardado na carta: {carta.GetComponent<Image>().sprite}");
    //        baralhoInicial.Add(carta);

    //        Debug.Log($"Nome do sprite sendo guardado no baralho: {baralhoInicial[i].GetComponent<Image>().sprite}");
    //        contador++;
    //    }

    //    Debug.Log($"Quantidade de cartas no baralho = {baralhoInicial.Count}");
    //    Debug.Log($"Tipo de carta na posição 2: {baralhoInicial[1].GetComponent<Image>().sprite.name}");
    //    Debug.Log($"Tipo de carta na posição 3: {baralhoInicial[2].GetComponent<Image>().sprite.name}");
    //    baralhoInicial = Embaralhar(baralhoInicial);

    //    return baralhoInicial;
    //}

    private void IniciarBaralho(List<GameObject> baralho)
    {
        GameObject carta;

        for (int i = 0; i < MAXIMODECARTAS; i++)
        {
            carta = criarCartas.CriarCarta(i);
            Debug.Log($"Nome do sprite sendo guardado na carta: {carta.GetComponent<Image>().sprite}");
            baralho.Add(InstanciaBaralho(carta, localBaralho));
            
            Debug.Log($"Nome do sprite sendo guardado no baralho: {baralho[i].GetComponent<Image>().sprite}");
            Debug.Log($"Nome do sprite sendo guardado no baralho para posição 0: {baralho[0].GetComponent<Image>().sprite}");
        }

        Debug.Log($"Quantidade de cartas no baralho = {baralho.Count}");
        Debug.Log($"Tipo de carta na posição 2: {baralho[1].GetComponent<Image>().sprite.name}");
        Debug.Log($"Tipo de carta na posição 3: {baralho[2].GetComponent<Image>().sprite.name}");
        baralho = Embaralhar(baralho);
    }

    private List<GameObject> Embaralhar(List<GameObject> baralho)
    {
        baralho = baralho.OrderBy(item => Random.value).ToList();

        return baralho;
    }

    private GameObject InstanciaBaralho(GameObject carta, Transform localBaralho)
    {
        GameObject cartaAux;
        cartaAux = Instantiate(carta, localBaralho);
        return cartaAux;
    }
}
