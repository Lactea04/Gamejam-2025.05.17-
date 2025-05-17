using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* �������� ���� �� ���� ��� */
public class StageManager : MonoBehaviour
{
    private SceneLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        // SceneLoader�� ã�� �Ҵ�
        loader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "user") // ������ ��ǥ������ �����ߴٸ�
        {
            loader.LoadMaintenance();
        }
    }

    public void OnEnterStage()
    {

    }
}
