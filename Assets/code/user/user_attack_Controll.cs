using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public Transform firePoint;  // 마우스를 바라볼 기준점

    private PlayerStats stats;
    private float attackCooldown = 0f;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        if (stats == null)
        {
            Debug.LogError("PlayerStats 컴포넌트가 필요합니다!");
        }

        if (firePoint == null)
        {
            Debug.LogError("FirePoint가 연결되지 않았습니다!");
        }
    }

    void Update()
    {
        RotateTowardMouse();
        AutoAttack();
    }

    void RotateTowardMouse()
    {
        if (firePoint == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - firePoint.position;
        direction.z = 0f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void AutoAttack()
    {
        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
            return;
        }

        // 자동 공격 트리거
        Debug.Log($"🗡️ 자동 근접 공격 발생! 방향: {firePoint.right}, 공격력: {stats.attackPower}");

        attackCooldown = 1f / stats.attackSpeed; // 쿨타임 = 1 / 초당 공격 횟수
    }
}

