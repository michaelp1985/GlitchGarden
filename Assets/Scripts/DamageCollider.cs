using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        FindObjectOfType<PlayerHealth>().TakeDamage(1);
    }
}
