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



    private ClothesWashingModel clothesModel;
    private DishWashingModel dishModel;
    private BodyWashingModel bodyModel;
    private SanitationModel sanModel;



    void Start()
    {
        instance = this;
        CreateModels();
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

    public void CreateModels() {
        clothesModel = new ClothesWashingModel();
        dishModel = new DishWashingModel();
        bodyModel = new BodyWashingModel();
        sanModel = new SanitationModel();
    }

    public void AddWaterUsage(int typeOfWaterUsage)
    {
        switch (typeOfWaterUsage)
        {
            case 0:
                {
                    clothesModel.AddToWaterUsed();
                    break;
                }
            case 1:
                {
                    dishModel.AddToWaterUsed();
                    break;
                }
            case 2:
                {
                    sanModel.AddToWaterUsed();
                    break;
                }
            case 3:
                {
                    bodyModel.AddToWaterUsed();
                    break;
                }
        }

    }

    public void LoadPrefences()
    {
        if (PlayerPrefs.HasKey(BODY_WASH_KEY))
        {
            bodyModel.myType = (BodyWashingModel.Type)PlayerPrefs.GetInt(BODY_WASH_KEY);
        }
        if (PlayerPrefs.HasKey(DISHES_WASH_KEY))
        {
            dishModel.myType = (DishWashingModel.Type)PlayerPrefs.GetInt(DISHES_WASH_KEY);
        }
        if (PlayerPrefs.HasKey(CLOTHES_WASH_KEY))
        {
            clothesModel.myType = (ClothesWashingModel.Type)PlayerPrefs.GetInt(CLOTHES_WASH_KEY);
        }
		if (PlayerPrefs.HasKey(WATER_USAGE_LEVEL_KEY)) 
		{
			WaterTotalManager.instance.totalWaterUsage = PlayerPrefs.GetInt(WATER_USAGE_LEVEL_KEY);
		}
    }

    public void SetBodyWashPreference(int newType)
    {
        PlayerPrefs.SetInt(BODY_WASH_KEY, newType);
        bodyModel.myType = (BodyWashingModel.Type)newType;
    }

    public void SetDishesWashPreference(int newType)
    {
        PlayerPrefs.SetInt(DISHES_WASH_KEY, newType);
        dishModel.myType = (DishWashingModel.Type)newType;
    }

    public void SetClothesWashPreference(int newType)
    {
        PlayerPrefs.SetInt(CLOTHES_WASH_KEY, newType);
        clothesModel.myType = (ClothesWashingModel.Type)newType;
    }

	public void SetWaterLevel (float waterLevel) {
		PlayerPrefs.SetFloat(WATER_USAGE_LEVEL_KEY, waterLevel);
	}

	public float GetWaterLevel () {
		return PlayerPrefs.GetFloat(WATER_USAGE_LEVEL_KEY);
	}
}
