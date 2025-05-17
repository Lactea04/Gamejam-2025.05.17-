using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public GameObject weaponPrefab;
    public float attackInterval = 1.5f;
    public float weaponOffset = 1.2f; // 플레이어로부터 얼마나 떨어질지

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackInterval)
        {
            Attack();
            timer = 0f;
        }
    }

    void Attack()
    {
        // 회전용 빈 오브젝트 생성 (피벗)
        GameObject pivot = new GameObject("WeaponPivot");
        pivot.transform.position = transform.position;
        pivot.transform.parent = transform;

        // 무기 생성 후 pivot 자식으로 배치
        GameObject weapon = Instantiate(weaponPrefab, pivot.transform);
        weapon.transform.localPosition = Vector3.right * weaponOffset; // 오른쪽 방향으로 오프셋

        // 피벗에 회전 스크립트 추가
        WeaponPivotRotator rotator = pivot.AddComponent<WeaponPivotRotator>();
        rotator.duration = 0.3f;
        rotator.angle = 180f;

        // 피벗과 무기를 공격 후 제거
        Destroy(pivot, rotator.duration);
    }
}