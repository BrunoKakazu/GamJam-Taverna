using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_", menuName = "Scriptable Objects/Card/Common")]
public class CardData : ScriptableObject
{

    [Header("IdCarta")]
    public string cardName; //D� nome � carta
    public Sprite cardSprite; //Para escolher o sprite da cartinha
    

    [Header("Valor")]
    public int value; //D� o valor � carta
    public bool isAce; //Verifica se a carta � o as, que pode valer 1 ou 11


}
