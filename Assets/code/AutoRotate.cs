using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // 회전 축 (기본: Y축)
    public float rotationSpeed = 90f; // 초당 회전 속도 (도 단위)

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}