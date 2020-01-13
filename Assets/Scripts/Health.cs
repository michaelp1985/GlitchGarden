using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    
    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }

    public float GetHealth()
    {
        return this.health;
    }

    private void TriggerDeathVFX()
    {
        if (deathVFX)
        {
            var deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 2f);
        }
    }
}
