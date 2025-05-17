using UnityEngine;

public class WeaponSwing : MonoBehaviour
{
    public float swingDuration = 0.3f;
    public float swingAngle = 180f;

    private float timer = 0f;
    private float startAngle;
    private float endAngle;

    void Start()
    {
        startAngle = -swingAngle / 2f;
        endAngle = swingAngle / 2f;
        transform.localRotation = Quaternion.Euler(0f, 0f, startAngle);
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / swingDuration;
        float angle = Mathf.Lerp(startAngle, endAngle, t);
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);

        if (t >= 1f)
        {
            Destroy(gameObject); // 휘두르고 나서 제거
        }
    }
}