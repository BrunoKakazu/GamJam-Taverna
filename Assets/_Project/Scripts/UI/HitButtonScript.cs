using UnityEngine;

public class HitButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject cardSpace;
    [SerializeField] private GameObject cardPrfab;
    private int cardCount = 0;
    [SerializeField] private int cardCountLimit = 13;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullCard()
    {
        if (cardCount < cardCountLimit)
        {
            Instantiate(cardPrfab, cardSpace.transform);
            cardCount++;
        }
    }
}
