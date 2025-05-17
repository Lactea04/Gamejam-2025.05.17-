using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public Transform firePoint;           // 무기/총알 발사 위치
    public GameObject projectilePrefab;   // 투사체 프리팹

    private PlayerStats stats;
    private float attackCooldown = 0f;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        if (stats == null)
        {
            Debug.LogError("PlayerStats 컴포넌트가 필요합니다!");
        }
    }

    void Update()
    {
        RotateWeaponTowardMouse();
        AutoAttack();
    }

    void RotateWeaponTowardMouse()
    {
        if (firePoint == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - firePoint.position;
        dir.z = 0f;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void AutoAttack()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

        if (attackCooldown <= 0f)
        {
            Fire();
            attackCooldown = 1f / stats.attackSpeed; // 쿨타임 = 초당 공격 수 기준
        }
    }

    void Fire()
    {
        if (projectilePrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 direction = firePoint.right;
            rb.velocity = direction * 10f;
        }

        // ✅ 로그 출력
        Debug.Log($"🗡️ 자동 공격! 방향: {firePoint.right}, 공격 속도: {stats.attackSpeed}/s");
    }
}
