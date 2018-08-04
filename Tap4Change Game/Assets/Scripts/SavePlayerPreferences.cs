using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPreferences : MonoBehaviour
{
    public static SavePlayerPreferences instance;
    public const string BODY_WASH_KEY = "BodyWashPreference";
    public const string DISHES_WASH_KEY = "DishesWashPreference";
    public const string CLOTHES_WASH_KEY = "ClothesWashPreference";
	public const string WATER_USAGE_LEVEL_KEY = "WaterUsageLevel";

    public BodyWashType selectedBodyWashType;
    public DishesWashType selectedDishesWashType;
    public ClothesWashType selectedClothesWashType;

    public enum BodyWashType
    {
        Shower,
        Bath,
        SpongeBath
    }

    public enum DishesWashType
    {
        Hand,
        Machine
    }

    public enum ClothesWashType
    {
        Hand,
        Machine
    }


    void Start()
    {
        instance = this;
        SetInitialSelections();
    }

    public void SetInitialDailyValues () {
        PlayerPrefs.SetInt(WATER_USAGE_LEVEL_KEY, 0);
    }

    public void SetInitialSelections () {
        SetBodyWashPreference(0);
        SetClothesWashPreference(0);
        SetDishesWashPreference(0);
    }

    public void LoadPrefences()
    {
        if (PlayerPrefs.HasKey(BODY_WASH_KEY))
        {
            selectedBodyWashType = (BodyWashType)PlayerPrefs.GetInt(BODY_WASH_KEY);
        }
        if (PlayerPrefs.HasKey(DISHES_WASH_KEY))
        {
            selectedDishesWashType = (DishesWashType)PlayerPrefs.GetInt(DISHES_WASH_KEY);
        }
        if (PlayerPrefs.HasKey(CLOTHES_WASH_KEY))
        {
            selectedClothesWashType = (ClothesWashType)PlayerPrefs.GetInt(CLOTHES_WASH_KEY);
        }
		if (PlayerPrefs.HasKey(WATER_USAGE_LEVEL_KEY)) 
		{
			WaterTotalManager.instance.totalWaterUsage = PlayerPrefs.GetInt(WATER_USAGE_LEVEL_KEY);
		}
    }

    public void SetBodyWashPreference(int newType)
    {
        PlayerPrefs.SetInt(BODY_WASH_KEY, newType);
        selectedBodyWashType = (BodyWashType)newType;
    }

    public void SetDishesWashPreference(int newType)
    {
        PlayerPrefs.SetInt(DISHES_WASH_KEY, newType);
        selectedDishesWashType = (DishesWashType)newType;
    }

    public void SetClothesWashPreference(int newType)
    {
        PlayerPrefs.SetInt(CLOTHES_WASH_KEY, newType);
        selectedClothesWashType = (ClothesWashType)newType;
    }

	public void SetWaterLevel (float waterLevel) {
		PlayerPrefs.SetFloat(WATER_USAGE_LEVEL_KEY, waterLevel);
	}

	public float GetWaterLevel () {
		return PlayerPrefs.GetFloat(WATER_USAGE_LEVEL_KEY);
	}
}
