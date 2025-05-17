using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    private GameObject user; //추적할 대상 (플레이어)
    private Rigidbody2D rb;

    public float speed = 3f; // 이동 속도

    public void Initialized(GameObject _user)
    {
        user = _user;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (user == null) return;
        Vector2 direction = (user.transform.position - transform.position).normalized; //방향벡터 계산
        rb.velocity = direction * speed; // 속도 설정하여 이동
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
