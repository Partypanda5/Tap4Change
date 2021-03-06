﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesWashingModel : DataModel
{
    public enum Type
    {
        HandWash,
        WashingMachine
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
            case (Type.WashingMachine):
                {
                    WaterTotalManager.instance.AddToTotal(75);
                    break;
                }
        }
    }

}
