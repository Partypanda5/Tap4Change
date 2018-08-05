using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanitationModel : DataModel {
	
    public void AddToWaterUsed () {
        WaterTotalManager.instance.AddToTotal(15);
    }
}
