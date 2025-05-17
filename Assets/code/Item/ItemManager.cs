using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 재료 수집 현황 관리하는 스크립트 */
public class ItemManager : MonoBehaviour
{
    // 싱글톤
    public static ItemManager Instance;
    // 각 재료를 보관하는 dictionary
    public Dictionary<string, int> materialCounts = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    // 재료 추가 및 감소
    public void AddMaterial(string materialName, int amount = 1)
    {
        if (!materialCounts.ContainsKey(materialName))
        {
            materialCounts[materialName] = 0;
        }
        materialCounts[materialName] += amount;
        Debug.Log(materialName + " : " + materialCounts[materialName]);
    }

    // 재료 확인
    public int GetMaterialCount(string materialName)
    {
        return materialCounts.TryGetValue(materialName, out int count) ? count : 0;
    }
}
