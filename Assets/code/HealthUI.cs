using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image fillImage;            // 체력바 이미지 (Image Type: Filled)
    public PlayerStats playerStats;    // PlayerStats를 참조하도록 수정됨

    void Update()
    {
        if (playerStats != null && fillImage != null)
        {
            float ratio = (float)playerStats.currentHealth / playerStats.maxHealth;
            fillImage.fillAmount = Mathf.Clamp01(ratio);
        }
    }
}
