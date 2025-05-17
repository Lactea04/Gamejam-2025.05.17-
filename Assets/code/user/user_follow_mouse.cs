using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_follow_mouse : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("❌ SpriteRenderer가 연결되지 않았습니다.");
        }
    }

    void Update()
    {
        if (spriteRenderer == null) return;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float directionX = mouseWorldPosition.x - transform.position.x;

        // 좌우 전환만 적용
        spriteRenderer.flipX = directionX > 0f;
    }
}
