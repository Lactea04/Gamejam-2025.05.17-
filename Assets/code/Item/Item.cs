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
            if (collision.gameObject.tag == "ItemRadius") // �÷��̾��� ���� ������ ��Ҵٸ�
            {
                Destroy(gameObject);
                isCollected = true;
                // ItemManager�� ��� �߰� �� �����ϱ�
                ItemManager.Instance.AddMaterial(name);
            }
        }

       
    }
}
