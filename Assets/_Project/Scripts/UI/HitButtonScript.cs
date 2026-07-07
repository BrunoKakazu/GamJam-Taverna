using UnityEngine;

public class HitButtonScript : MonoBehaviour
{
    [SerializeField] private GameMenagerScript GMScript;
    public bool hasGivenCards = false;

    void Awake()
    {
        GMScript = FindObjectsByType<GameMenagerScript>(FindObjectsSortMode.None)[0];
    }
    public void PullCard()
    {
        GMScript.GivePlayerCard();
        hasGivenCards = true;
    }
}
