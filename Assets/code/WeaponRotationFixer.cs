using UnityEngine;

public class WeaponRotationFixer : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // ���� ���� �� ȸ���� ���� (����)
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // �θ� ȸ���ص� �� ȸ���� ����
        transform.rotation = initialRotation;
    }
}