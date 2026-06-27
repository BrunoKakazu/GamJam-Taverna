using UnityEngine;

public class HitButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject cardSpace;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private DeckScript deckScript;
    private int cardCount = 0;
    [SerializeField] private int cardCountLimit = 13;

    void Awake()
    {
        deckScript = FindObjectsByType<DeckScript>(FindObjectsSortMode.None)[0];
    }
    public void PullCard()
    {
        if (cardCount < cardCountLimit)
        {
            GameObject pulledCard = Instantiate(cardPrefab, cardSpace.transform);
            pulledCard.GetComponent<CardScript>().CreateCard(deckScript.GiveCardData());
            cardCount++;
        }
    }
}
