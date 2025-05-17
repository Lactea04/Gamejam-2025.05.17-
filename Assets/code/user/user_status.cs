using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("체력")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("공격력")]
    public float attackPower = 10f;

    [Header("이동 속도")]
    public float moveSpeed = 5f;

    [Header("공격 속도 (초당 공격 수)")]
    public float attackSpeed = 1.0f; // 초당 공격 횟수 (예: 2.0f = 0.5초마다 공격)

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"🩸 체력: {currentHealth}/{maxHealth}");
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"🩹 체력 회복: {currentHealth}/{maxHealth}");
    }

    public void IncreaseAttackSpeed(float amount)
    {
        attackSpeed += amount;
        attackSpeed = Mathf.Clamp(attackSpeed, 0.1f, 100f);
        Debug.Log($"⚔️ 공격 속도 증가: {attackSpeed}회/초");
    }
}
