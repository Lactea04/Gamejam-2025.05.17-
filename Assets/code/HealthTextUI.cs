using UnityEngine;
using UnityEngine.UI;

public class HealthTextUI : MonoBehaviour
{
    public Text healthText;
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text = $"{playerHealth.currentHealth} / {playerHealth.maxHealth}";
        }
    }
}