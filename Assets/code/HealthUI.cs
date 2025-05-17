using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image fillImage;
    public user_status currentHealth;

    void Update()
    {
        if (currentHealth != null && fillImage != null)
        {
            float ratio = (float)currentHealth.currentHealth / currentHealth.maxHealth;
            fillImage.fillAmount = Mathf.Clamp01(ratio);
        }
    }
}