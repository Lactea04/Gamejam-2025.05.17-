using UnityEngine;
using UnityEngine;

public class potatomove : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // ȸ�� �� (�⺻: Y��)
    public float rotationSpeed = 90f; // �ʴ� ȸ�� �ӵ� (�� ����)

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
