using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public Transform firePoint;         // 무기를 생성할 위치
    public GameObject stickPrefab;      // 회전 공격 무기 프리팹 (WeaponSwing 포함)

    private PlayerStats stats;
    private float attackCooldown = 0f;

    void Start()
    {
        stats = GetComponent<PlayerStats>();

        if (firePoint == null)
            Debug.LogError("❌ FirePoint가 연결되지 않았습니다.");

        if (stickPrefab == null)
            Debug.LogError("❌ stickPrefab이 연결되지 않았습니다.");
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
        firePoint.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void AutoAttack()
    {
        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
            return;
        }

        attackCooldown = 1f / stats.attackSpeed;

        // 스틱 생성 및 firePoint 방향에 맞춰 회전 배치
        GameObject stick = Instantiate(stickPrefab, firePoint.position, firePoint.rotation, transform);
        stick.GetComponent<WeaponSwing>().init(firePoint);
        Debug.Log("🪵 스틱 공격 발생!");

        // WeaponSwing이 알아서 회전하고 일정 시간 뒤 Destroy 처리
    }
}
