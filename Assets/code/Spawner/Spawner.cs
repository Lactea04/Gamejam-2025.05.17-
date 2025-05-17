using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 스폰시킬 오브젝트. 적이든 아군이든 관계 X
    [SerializeField]
    private GameObject spawnTarget;
    // 쿨타임. 0보다 작아지면 spawnTarget 스폰함
    private float currentCoolTime = 0.0f;
    // 몇 초 기다릴지 결정
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
        // TODO : obj 초기화
        if(obj.TryGetComponent<enemy_move>(out enemy_move enemy))
        {
            enemy.Initialize(gameObject);
        }
    }
}
