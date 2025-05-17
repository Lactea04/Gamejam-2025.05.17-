using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 스테이지 시작 및 종료 담당 */
public class StageManager : MonoBehaviour
{
    private SceneLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        // SceneLoader를 찾아 할당
        loader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "user") // 유저가 목표지점에 도착했다면
        {
            loader.LoadMaintenance();
        }
    }

    public void OnEnterStage()
    {

    }
}
