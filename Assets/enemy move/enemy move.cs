using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    private GameObject user; //������ ��� (�÷��̾�)
    private Rigidbody2D rb;

    public float speed = 3f; // �̵� �ӵ�

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
        Vector2 direction = (user.transform.position - transform.position).normalized; //���⺤�� ���
        rb.velocity = direction * speed; // �ӵ� �����Ͽ� �̵�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
