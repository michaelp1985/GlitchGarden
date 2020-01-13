using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void Start()
    {
        SetDifficulty();
    }

    public void SetDifficulty()
    {
        Health health = GetComponent<Health>();
        health.SetHealth(PlayerPrefsController.GetDifficulty() * 50f);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherObject.GetComponent<Defender>())
        {            
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
