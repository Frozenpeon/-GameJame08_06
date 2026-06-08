using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    public Health playerhealth;
    public RectTransform UpperImage;
    public RectTransform UnderImage;

    public void init(Health health)
    {
        playerhealth = health;
        playerhealth.takesDamage += onPlayerDamage;
    }
    public void onPlayerDamage(int maxHealth, int currentHealth)
    {   
        UpperImage.sizeDelta = new Vector2((float)((float)currentHealth / (float)maxHealth) * UpperImage.sizeDelta.x, UpperImage.sizeDelta.y);
    }

}
