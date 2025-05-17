using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject user; //추적할 대상 (플레이어)
    private Rigidbody2D rb;
    public GameObject dropItemPrefab; // 드랍할 아이템을 연결해 놓을 변수
    private SpriteRenderer spriteRenderer;
    private bool isDead = false;
    
    public int hp = 10; // 적의 피통
    public float speed = 3f; // 이동 속도

    public void Initialized(GameObject _user)
    {
        user = _user;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;// 회전 고정
    }

    private void FixedUpdate()
    {
        if (user == null) return;
        Vector2 direction = (user.transform.position - transform.position).normalized; //방향벡터 계산
        rb.velocity = direction * speed; // 속도 설정하여 이동

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
            // 현재 적 위치에 드랍 아이템 생성
            Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
            // 사망 처리
            StartCoroutine(FadeOut());
        }
    }


    


    // Update is called once per frame
    void Update()
    {

    }



    // 캐릭터를 점점 투명하게 만들어 사라지게 하는 코루틴
    IEnumerator FadeOut()
    {
        // 이 오브젝트의 Renderer 컴포넌트를 가져옴 (외형 관련)
        Renderer renderer = GetComponent<Renderer>();

        // 현재 머티리얼의 색상을 가져옴 (R, G, B, A 포함)
        Color color = renderer.material.color;

        rb.simulated = false;
        // 알파(투명도)를 1 → 0까지 매 프레임마다 감소시킴
        for (float alpha = 1f; alpha > 0f; alpha -= Time.deltaTime)
        {
            // 알파 값만 줄이고 색상 다시 적용
            color.a = alpha;
            renderer.material.color = color;

            // 다음 프레임까지 잠깐 대기
            yield return null;
        }

        // 완전히 사라지면 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
