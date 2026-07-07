using UnityEngine;

public class StayButtonScript : MonoBehaviour
{
    private GameMenagerScript gameMenagerScript;
    public bool hasStayed = false;

    private void Awake()
    {
        gameMenagerScript = FindObjectsByType<GameMenagerScript>(FindObjectsSortMode.None)[0];
    }
    public void Stay()
    {
        hasStayed = true;
    }
}
