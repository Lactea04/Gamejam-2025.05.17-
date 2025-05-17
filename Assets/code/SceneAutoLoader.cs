using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAutoLoader : MonoBehaviour
{
    public float delay = 30f; // 몇 초 후에 전환할지
    public string nextSceneName; // 전환할 다음 씬 이름

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}