using UnityEngine;

public class CameraFollowClamped2D : MonoBehaviour
{
    public Transform target;                // 따라갈 대상 (플레이어)
    public Vector2 minBounds;               // 맵 왼쪽 아래 (xMin, yMin)
    public Vector2 maxBounds;               // 맵 오른쪽 위 (xMax, yMax)
    public float smoothSpeed = 0.1f;
    public Vector3 offset = new Vector3(0, 0, -10f);

    private float camHalfHeight;
    private float camHalfWidth;

    void Start()
    {
        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // 카메라 시점의 범위를 맵 안으로 제한 (Clamp)
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
    }
}
