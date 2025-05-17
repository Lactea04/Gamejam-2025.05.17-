using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // 따라갈 대상 (플레이어)
    public float smoothSpeed = 0.125f;  // 따라가는 속도
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // 카메라 위치 보정

    void LateUpdate()
    {
        if (target == null) return;

        // 따라갈 목표 위치
        Vector3 desiredPosition = target.position + offset;

        // 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
