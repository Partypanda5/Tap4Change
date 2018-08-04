using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTotalManager : MonoBehaviour {

	public static WaterTotalManager instance;
	public int totalWaterUsage { get; set; }
	public float totalWaterUsagePercentage = 0;

	void Start() {
		instance = this;
	}

	public void AddToTotal (int amountToAdd) {
        totalWaterUsage += amountToAdd;
		totalWaterUsagePercentage = (245 - totalWaterUsage)/2.45f;
		Debug.Log("WaterUsage: " + totalWaterUsage + " Percentage: " + totalWaterUsagePercentage);
		TapDisplayManager.instance.ChangeTapState();		
	}
}
