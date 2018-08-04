using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataModel {
	public int waterUsage {get; set;}

	public void AddToTotal(int amountToAdd) {
		this.waterUsage = (this.waterUsage + amountToAdd);
	}
}
