using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject user; //������ ��� (�÷��̾�)
    private Rigidbody2D rb;
    public GameObject dropItemPrefab; // ����� �������� ������ ���� ����
    private SpriteRenderer spriteRenderer;
    private bool isDead = false;
    
    public int hp = 10; // ���� ����
    public float speed = 3f; // �̵� �ӵ�

    public void Initialized(GameObject _user)
    {
        user = _user;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;// ȸ�� ����
    }

    private void FixedUpdate()
    {
        if (user == null || isDead) return;
        Vector2 direction = (user.transform.position - transform.position).normalized; //���⺤�� ���
        rb.velocity = direction * speed; // �ӵ� �����Ͽ� �̵�

        if (direction.x < 0)
            spriteRenderer.flipX = false;
        else if (direction.x > 0)
            spriteRenderer.flipX = true;
    }

    public void onhit(int damage)
    {
        hp -= damage;
        if (hp <= 0 && !isDead)
        {
            isDead = true;
            // ����
            rb.velocity = Vector2.zero;
            // �浹 ��Ȱ��ȭ
            gameObject.GetComponent<Collider2D>().enabled = false;
            // ���� �� ��ġ�� ��� ������ ����
            Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
            // ��� ó��
            StartCoroutine(FadeOut());
        }
    }
    // ĳ���͸� ���� �����ϰ� ����� ������� �ϴ� �ڷ�ƾ
    IEnumerator FadeOut()
    {
        // �� ������Ʈ�� Renderer ������Ʈ�� ������ (���� ����)
        Renderer renderer = GetComponent<Renderer>();

        // ���� ��Ƽ������ ������ ������ (R, G, B, A ����)
        Color color = renderer.material.color;

        rb.simulated = false;
        // ����(������)�� 1 �� 0���� �� �����Ӹ��� ���ҽ�Ŵ
        for (float alpha = 1f; alpha > 0f; alpha -= Time.deltaTime)
        {
            // ���� ���� ���̰� ���� �ٽ� ����
            color.a = alpha;
            renderer.material.color = color;

            // ���� �����ӱ��� ��� ���
            yield return null;
        }

        // ������ ������� ������Ʈ �ı�
        Destroy(gameObject);
    }
}
