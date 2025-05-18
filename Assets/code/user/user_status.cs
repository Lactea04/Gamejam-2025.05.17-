using UnityEngine;
using UnityEngine.UI;

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
    public float attackSpeed = 1.0f;

    public GameObject gameover;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // 체력 감소
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"🩸 Player HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 체력 사망 처리
    void Die()
    {
        Debug.Log("☠️ Player Died!");

        Time.timeScale = 0.0f;
        gameover.SetActive(true);
    }

    // 공격 속도 증가
    public void IncreaseAttackSpeed(float amount)
    {
        attackSpeed += amount;
        attackSpeed = Mathf.Clamp(attackSpeed, 0.1f, 100f);
        Debug.Log($"⚔️ 공격 속도 증가: {attackSpeed}회/초");
    }

    // 이동 속도 증가 (선택적)
    public void IncreaseMoveSpeed(float amount)
    {
        moveSpeed += amount;
        Debug.Log($"🏃 이동 속도 증가: {moveSpeed}");
    }

    // 공격력 증가 (선택적)
    public void IncreaseAttackPower(float amount)
    {
        attackPower += amount;
        Debug.Log($"💥 공격력 증가: {attackPower}");
    }
}
