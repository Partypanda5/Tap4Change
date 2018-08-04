using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTotalManager : MonoBehaviour {

	public int totalWaterUsage {get; set;}

	public void AddToTotal (int amountToAdd) {
		totalWaterUsage += amountToAdd;
	}
}
