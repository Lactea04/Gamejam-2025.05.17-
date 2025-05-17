using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ��� ���� ��Ȳ �����ϴ� ��ũ��Ʈ */
public class ItemManager : MonoBehaviour
{
    // �̱���
    public static ItemManager Instance;
    // �� ��Ḧ �����ϴ� dictionary
    public Dictionary<string, int> materialCounts = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }

    // ��� �߰� �� ����
    public void AddMaterial(string materialName, int amount = 1)
    {
        if (!materialCounts.ContainsKey(materialName))
        {
            materialCounts[materialName] = 0;
        }
        materialCounts[materialName] += amount;
        Debug.Log(materialName + " : " + materialCounts[materialName]);
    }

    // ��� Ȯ��
    public int GetMaterialCount(string materialName)
    {
        return materialCounts.TryGetValue(materialName, out int count) ? count : 0;
    }
}
