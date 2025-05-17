using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        // 씬을 바꿔도 남아있도록
        DontDestroyOnLoad(this);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextStage()
    {
        // StageScene 불러오기
        LoadScene("StageScene");
    }

    public void LoadMaintenance()
    {
        // CookeScene 불러오기
        LoadScene("CookScene");
    }
}
