using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishWashingModel : DataModel {
	public enum Type{
		HandWash,
		DishWasher
	}

    public Type myType;

    public void AddToWaterUsed()
    {
        switch (myType)
        {
            case (Type.HandWash):
                {
                    WaterTotalManager.instance.AddToTotal(18);
                    break;
                }
            case (Type.DishWasher):
                {
                    WaterTotalManager.instance.AddToTotal(45);
                    break;
                }
        }
    }

}
