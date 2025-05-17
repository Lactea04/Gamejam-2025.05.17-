using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        // ���� �ٲ㵵 �����ֵ���
        DontDestroyOnLoad(this);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextStage()
    {
        // StageScene �ҷ�����
        LoadScene("StageScene");
    }

    public void LoadMaintenance()
    {
        // CookeScene �ҷ�����
        LoadScene("CookScene");
    }
}
