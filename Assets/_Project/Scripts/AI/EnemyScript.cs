using UnityEngine;

public class EnemyScript : MonoBehaviour
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
