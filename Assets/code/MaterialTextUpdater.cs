using UnityEngine;
using UnityEngine.UI; // UI.Text     

public class MaterialTextUpdater : MonoBehaviour
{
    public Text uiText;               // Unity �⺻ UI       

    public string materialName;      
    public ItemManager materialManager; // materialCounts�� ������ �ִ� Ŭ����

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