using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void Start()
    {
        SetDifficulty();
    }

    public void SetDifficulty()
    {
        Health health = GetComponent<Health>();
        health.SetHealth(PlayerPrefsController.GetDifficulty() * 20f);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
