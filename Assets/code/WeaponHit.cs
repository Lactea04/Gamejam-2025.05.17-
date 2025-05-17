using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    public int damage = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy enemy = collision.GetComponent<enemy>();
            if (enemy != null)
            {
                enemy.onhit(damage);
            }
        }
    }
}