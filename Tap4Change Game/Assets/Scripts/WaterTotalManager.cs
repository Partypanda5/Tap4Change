using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTotalManager : MonoBehaviour
{

    public static WaterTotalManager instance;
    public int totalWaterUsage { get; set; }
    public float totalWaterUsagePercentage = 0;

    private ClothesWashingModel clothesModel;
    private DishWashingModel dishModel;
    private BodyWashingModel bodyModel;
    private SanitationModel sanModel;

    void Start()
    {
        instance = this;
    }

    public void Initialize()
    {
        clothesModel = new ClothesWashingModel();
        clothesModel.myType = (ClothesWashingModel.Type)SavePlayerPreferences.instance.selectedClothesWashType;
        dishModel = new DishWashingModel();
        dishModel.myType = (DishWashingModel.Type)SavePlayerPreferences.instance.selectedClothesWashType;
        bodyModel = new BodyWashingModel();
        bodyModel.myType = (BodyWashingModel.Type)SavePlayerPreferences.instance.selectedClothesWashType;
        sanModel = new SanitationModel();
    }

    public void UpdateTypes () {
        clothesModel.myType = (ClothesWashingModel.Type)SavePlayerPreferences.instance.selectedClothesWashType;
        dishModel.myType = (DishWashingModel.Type)SavePlayerPreferences.instance.selectedClothesWashType;
        bodyModel.myType = (BodyWashingModel.Type)SavePlayerPreferences.instance.selectedClothesWashType;
    }

    public void AddToTotal(int amountToAdd)
    {
        Debug.Log("add to total called with: " + amountToAdd);
        if (totalWaterUsage < 230)
        {
            totalWaterUsage += amountToAdd;
            totalWaterUsagePercentage = (245 - totalWaterUsage) / 2.45f;
            TapDisplayManager.instance.ChangeTapState();
            PeopleInQueueManager.instance.ChangeTargetTimeToFetchWater();
            DamDisplayManager.instance.ChangeDamLevel();
        }
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
}
