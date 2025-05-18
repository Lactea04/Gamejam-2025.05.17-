using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 재료 수집 현황 관리하는 스크립트 */
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

            // 초기 재료 등록
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
