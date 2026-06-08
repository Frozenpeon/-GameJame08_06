using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAnim playerAnim;
    [SerializeField] private Sprite deathSprite;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
            playerAnim.SetDeathSprite();
        }
    }
}
