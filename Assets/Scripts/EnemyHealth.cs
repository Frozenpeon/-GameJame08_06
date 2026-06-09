using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Sprite[] deathSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private CapsuleCollider2D capsuleCollider2D;
    private float currentHealth;

    public Action<float, float> takesDamage;
    public Action<GameObject> onDeath;
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
    {
        onDeath?.Invoke(gameObject);
        spriteRenderer.enabled = false;
        enemyMovement.SetCanMove(false);
        capsuleCollider2D.enabled = false;
        animator.SetTrigger("OnDeath");
        print("I die");
        Destroy(gameObject, 2f);
    }
}
