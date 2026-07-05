using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 63;
    public int currenthealth;

    private void Start()
    {
        currenthealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
    }
}
