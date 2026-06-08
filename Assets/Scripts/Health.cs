using JetBrains.Annotations;
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private PlayerMovement playerMovement;
    private int currentHealth;

    public Action<int, int> takesDamage;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        takesDamage?.Invoke(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("YOU DIED");
        if(playerMovement != null)
        {
            playerMovement.SetCanMove(false);
        }
    }
}
