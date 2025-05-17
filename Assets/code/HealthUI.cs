using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image fillImage;            // ü�¹� �̹��� (Image Type: Filled)
    public PlayerStats playerStats;    // PlayerStats�� �����ϵ��� ������

    void Update()
    {
        if (playerStats != null && fillImage != null)
        {
            float ratio = (float)playerStats.currentHealth / playerStats.maxHealth;
            fillImage.fillAmount = Mathf.Clamp01(ratio);
        }
    }
}
