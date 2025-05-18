using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string foodName;
    public string[] materialNames;

    public void OnClickFoodButton()
    {
        int flag = 0;
        foreach (var item in materialNames)
        {
            if (!ItemManager.Instance.AddMaterial(item, -1)) flag++;
        }
        if(flag > 0) // ������ ��ᰡ �־��ٸ� �����
        {
            foreach (var item in materialNames)
            {
                ItemManager.Instance.AddMaterial(item, 1);
            }
            return;
        }
        FoodManager.Instance.makeFood(foodName);
    }
}
