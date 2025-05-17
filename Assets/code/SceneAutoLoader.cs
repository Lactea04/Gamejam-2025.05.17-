using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAutoLoader : MonoBehaviour
{
    public float delay = 30f; // �� �� �Ŀ� ��ȯ����
    public string nextSceneName; // ��ȯ�� ���� �� �̸�

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