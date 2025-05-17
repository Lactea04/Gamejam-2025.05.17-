using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public GameObject weaponPrefab;
    public float attackInterval = 1.5f;
    public float weaponOffset = 1.2f; // �÷��̾�κ��� �󸶳� ��������

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
        // ȸ���� �� ������Ʈ ���� (�ǹ�)
        GameObject pivot = new GameObject("WeaponPivot");
        pivot.transform.position = transform.position;
        pivot.transform.parent = transform;

        // ���� ���� �� pivot �ڽ����� ��ġ
        GameObject weapon = Instantiate(weaponPrefab, pivot.transform);
        weapon.transform.localPosition = Vector3.right * weaponOffset; // ������ �������� ������

        // �ǹ��� ȸ�� ��ũ��Ʈ �߰�
        WeaponPivotRotator rotator = pivot.AddComponent<WeaponPivotRotator>();
        rotator.duration = 0.3f;
        rotator.angle = 180f;

        // �ǹ��� ���⸦ ���� �� ����
        Destroy(pivot, rotator.duration);
    }
}