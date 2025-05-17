using UnityEngine;

public class WeaponRotationFixer : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // 무기 생성 시 회전값 저장 (고정)
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // 부모가 회전해도 내 회전은 고정
        transform.rotation = initialRotation;
    }
}