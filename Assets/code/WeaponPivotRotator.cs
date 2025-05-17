using UnityEngine;

public class WeaponPivotRotator : MonoBehaviour
{
    public float duration = 0.3f;
    public float angle = 180f;

    private float timer = 0f;
    private float startAngle;
    private float endAngle;

    void Start()
    {
        startAngle = -angle / 2f;
        endAngle = angle / 2f;
        transform.localRotation = Quaternion.Euler(0, 0, startAngle);
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);
        float currentAngle = Mathf.Lerp(startAngle, endAngle, t);
        transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
    }
}