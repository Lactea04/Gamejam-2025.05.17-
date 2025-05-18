using UnityEngine;
using UnityEngine.UI; // UI.Text     

public class MaterialTextUpdater : MonoBehaviour
{
    public Text uiText;               // Unity ±âº» UI       

    public string materialName;      

    void Update()
    {
        if (ItemManager.Instance == null) return;

        int count = 0;
        ItemManager.Instance.materialCounts.TryGetValue(materialName, out count);

        string display = $"{materialName}: {count}";

        if (uiText != null)
            uiText.text = display;
    }
}