using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ��� ���� ��Ȳ �����ϴ� ��ũ��Ʈ */
public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public Dictionary<string, int> materialCounts = new();
    private readonly string[] defaultMaterials = { "Bacon", "Egg", "Potato" };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // �ʱ� ��� ���
            foreach (string material in defaultMaterials)
            {
                materialCounts[material] = 0;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool AddMaterial(string materialName, int amount = 1)
    {
        if (!materialCounts.ContainsKey(materialName))
        {
            materialCounts[materialName] = 0;
        }
        materialCounts[materialName] += amount;
        Debug.Log(materialName + " : " + materialCounts[materialName]);
        return materialCounts[materialName] >= 0;
    }

    public int GetMaterialCount(string materialName)
    {
        return materialCounts.TryGetValue(materialName, out int count) ? count : 0;
    }
}
