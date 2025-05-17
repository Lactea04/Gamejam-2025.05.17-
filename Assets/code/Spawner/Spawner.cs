using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ������ų ������Ʈ. ���̵� �Ʊ��̵� ���� X
    [SerializeField]
    private GameObject spawnTarget;
    // ��Ÿ��. 0���� �۾����� spawnTarget ������
    private float currentCoolTime = 0.0f;
    // �� �� ��ٸ��� ����
    [SerializeField]
    private float coolTime = 5.0f;

    public GameObject user;
    

    // Update is called once per frame 
    void Update()
    {
        if(currentCoolTime < 0.0f)
        {
            Spawn();
            currentCoolTime = coolTime;
        }
        else
        {
            currentCoolTime -= Time.deltaTime;
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(spawnTarget, transform.position, Quaternion.identity);
        // TODO : obj �ʱ�ȭ
        if(obj.TryGetComponent<enemy_move>(out enemy_move enemy))
        {
            enemy.Initialize(gameObject);
        }
    }
}
