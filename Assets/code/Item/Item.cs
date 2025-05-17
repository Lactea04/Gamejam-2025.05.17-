using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string name;
    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected)
        {
            if (collision.gameObject.tag == "ItemRadius") // 플레이어의 수집 범위가 닿았다면
            {
                Destroy(gameObject);
                isCollected = true;
                // ItemManager에 재료 추가 후 삭제하기
                ItemManager.Instance.AddMaterial(name);
            }
        }

       
    }
}
