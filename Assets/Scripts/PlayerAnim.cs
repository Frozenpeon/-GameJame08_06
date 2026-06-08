using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Sprite[] idleSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float animationSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        AnimateIdle();
    }

    private void AnimateIdle()
    {
        int index = (int)(Time.time / animationSpeed) % idleSprites.Length;
        spriteRenderer.sprite = idleSprites[index];
    }
}
