using UnityEngine;

public class CameraFollowClamped2D : MonoBehaviour
{
    public Transform target;                // ���� ��� (�÷��̾�)
    public Vector2 minBounds;               // �� ���� �Ʒ� (xMin, yMin)
    public Vector2 maxBounds;               // �� ������ �� (xMax, yMax)
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

        // ī�޶� ������ ������ �� ������ ���� (Clamp)
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
    }
}
