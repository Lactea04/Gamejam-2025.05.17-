using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public static FoodManager Instance;
    public Dictionary<string, int> foodCount = new();
    public ItemManager itemManager;
    private readonly string[] defaultFoods = { "Bacon", "FriedEgg", "BEH" };
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 초기 음식 등록
            foreach (string material in defaultFoods)
            {
                foodCount[material] = 0;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeFood(string name, int amount = 1)
    {
        if (!foodCount.ContainsKey(name))
        {
            foodCount[name] = 0;
        }
        foodCount[name] += amount;
        Debug.Log(name + " : " + foodCount[name]);
    }
}
