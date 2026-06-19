using UnityEngine;

public enum EffectTiming { BeforeDraw, AfterDraw, OnDamageCalc, OnHandWin, OnHandLose } // Verifica etapa em que o jogo se encontra

[CreateAssetMenu(fileName = "Effect_", menuName = "Scriptable Objects/Card/Effect")]
public class EffectCardData : ScriptableObject
{
    [Header("CardId")]
    public string cardName;
    //public Sprite cardArt;

    [Header("Efeito")]
    public EffectTiming timing; // Identifica quando o efeito é ativado
    [SerializeReference]
    public ICardEffect effect; // Referência aos efeitos concretos

    [Header("Uso")]
    public int usesPerBattle = 1; // Quantas vezes a carta pode ser usada por batalha

}
