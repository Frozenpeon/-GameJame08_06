using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAnim playerAnim;
    [SerializeField] private Sprite deathSprite;
    private int currentHealth;

    public Action<int, int> takesDamage;

    public List<AudioClip> hurtSounds = new List<AudioClip>();
    public AudioSource hurtSound;
    public float hurtVolume;


    void Start()
    {
        currentHealth = maxHealth;
        hurtSound.volume = hurtVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>() != null) {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        takesDamage?.Invoke(maxHealth, currentHealth);
        hurtSound.clip = hurtSounds[UnityEngine.Random.Range(0, hurtSounds.Count)];
        hurtSound.Play();
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
