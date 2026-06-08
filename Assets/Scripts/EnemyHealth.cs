using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Sprite[] deathSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyMovement enemyMovement;
    private float currentHealth;

    public Action<float, float> takesDamage;
    public Action onDeath;
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        takesDamage?.Invoke(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {

            Die();
        }
    }

    private void Die()
    {   spriteRenderer.enabled = false;
        enemyMovement.SetCanMove(false);
        animator.SetTrigger("OnDeath");
        onDeath?.Invoke();
        Destroy(gameObject, 2f);
    }
}
