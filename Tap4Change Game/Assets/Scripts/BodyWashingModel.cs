﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyWashingModel : DataModel
{
    public enum Type
    {
        Shower,
        Bath,
        SpongeBath
    }

	public Type myType;

	public void AddToWaterUsed () {
		switch (myType) {
			case (Type.Shower) : {
				WaterTotalManager.instance.AddToTotal(15);
				break;
			}
			case (Type.Bath) : {
				WaterTotalManager.instance.AddToTotal(60);
				break;
			}
			case (Type.SpongeBath) : {
				WaterTotalManager.instance.AddToTotal(1);
				break;
			}
		}
	}

}
