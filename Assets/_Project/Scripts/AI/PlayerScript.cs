using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 63;
    public int currenthealth;

    private void Start()
    {
        currenthealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
    }
}
