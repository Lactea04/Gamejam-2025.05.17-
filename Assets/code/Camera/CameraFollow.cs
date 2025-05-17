using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // ���� ��� (�÷��̾�)
    public float smoothSpeed = 0.125f;  // ���󰡴� �ӵ�
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // ī�޶� ��ġ ����

    void LateUpdate()
    {
        if (target == null) return;

        // ���� ��ǥ ��ġ
        Vector3 desiredPosition = target.position + offset;

        // �ε巴�� �̵�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
