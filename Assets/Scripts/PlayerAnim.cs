using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Sprite[] idleSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float animationSpeed = 0.1f;
    [SerializeField] private Sprite deathSprite;
    private bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        AnimateIdle();
    }

    private void AnimateIdle()
    {
        if (isDead) return;
        int index = (int)(Time.time / animationSpeed) % idleSprites.Length;
        spriteRenderer.sprite = idleSprites[index];
    }
    public void SetDeathSprite()
    {
        isDead = true;
        spriteRenderer.sprite = deathSprite;
    }
}
