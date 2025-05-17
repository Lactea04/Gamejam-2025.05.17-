using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject baconPrefab;
    public Transform player;
    public float spawnInterval = 2f;
    public float spawnDistance = 8f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnMonster();
            timer = 0f;
        }
    }

    void SpawnMonster()
    {
        // �÷��̾� �ֺ� ���� ��ġ ���
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)player.position + spawnDirection * spawnDistance;

        Instantiate(baconPrefab, spawnPosition, Quaternion.identity);
    }
}