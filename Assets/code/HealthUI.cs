using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image fillImage;
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth != null && fillImage != null)
        {
            float ratio = (float)playerHealth.currentHealth / playerHealth.maxHealth;
            fillImage.fillAmount = Mathf.Clamp01(ratio);
        }
    }
}