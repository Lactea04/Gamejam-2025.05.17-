using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("💥 충돌 감지됨: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("🎯 Player 태그 확인됨");

            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                Debug.Log("⚔️ 데미지 적용 시작");
                playerStats.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("❗ PlayerStats 컴포넌트를 찾을 수 없음!");
            }
        }
    }
}
