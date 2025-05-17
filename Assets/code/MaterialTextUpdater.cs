using UnityEngine;
using UnityEngine.UI; // UI.Text     

public class MaterialTextUpdater : MonoBehaviour
{
    public Text uiText;               // Unity 기본 UI       

    public string materialName;      
    public ItemManager materialManager; // materialCounts를 가지고 있는 클래스

    private void Start()
    {
        materialManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
    }

    void Update()
    {
        if (materialManager == null) return;

        int count = 0;
        materialManager.materialCounts.TryGetValue(materialName, out count);

        string display = $"{materialName}: {count}";

        if (uiText != null)
            uiText.text = display;
    }
}