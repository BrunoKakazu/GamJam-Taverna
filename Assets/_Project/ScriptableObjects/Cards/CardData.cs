using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_", menuName = "Scriptable Objects/Card/Common")]
public class CardData : ScriptableObject
{
    [Header("IdCarta")]
    public int cardID; //Da o id da carta
    public Sprite cardSprite; //Para escolher o sprite da cartinha
    

    [Header("Valor")]
    public int value; //D� o valor � carta
    public bool isAce; //Verifica se a carta � o as, que pode valer 1 ou 11

    public GameObject prefab;

    
}
