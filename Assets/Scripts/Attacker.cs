﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] float currentSpeed = 1f;
    GameObject currentTarget;
    LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        levelController.AddAttacker();        
    }    

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damage);
        }
    }

    private void OnDestroy()
    {
        if (levelController != null)
            levelController.RemoveAttacker();
    }
}
