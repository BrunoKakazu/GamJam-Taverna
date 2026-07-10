using UnityEngine.UI;
using UnityEngine;
public class AnimationMenagerScript : MonoBehaviour
{
    private float animTime = 0.2f;
    [SerializeField] Transform deckArea;

    //[SerializeField] private 
    public void SpawnAnimation(GameObject carta, Transform finalPos)
    {
        carta.transform.position = deckArea.position;
        LeanTween.move(carta, finalPos.position, animTime).setOnComplete(() =>
        {
            carta.transform.SetParent(finalPos);
            carta.GetComponent<CardScript>().CardFlip();

        });
    }

    public void FlipAnimation(GameObject carta, Sprite back, bool hasToAnimate)
    {
        if (hasToAnimate)
        {
            carta.transform.LeanScaleX(0f, animTime).setOnComplete(() =>
            {
                carta.transform.LeanScaleX(1f, animTime);
                carta.GetComponent<Image>().sprite = back;
            });

        } else
        {
            carta.GetComponent <Image>().sprite = back;
        }
    }
}