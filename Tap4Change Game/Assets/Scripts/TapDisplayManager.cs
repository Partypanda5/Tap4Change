using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDisplayManager : MonoBehaviour
{

    public static TapDisplayManager instance;

    public enum TapState
    {
        Flow,
        Drip,
        Dry
    }

    private TapState currState { get; set; }

    void Start()
    {
        instance = this;
    }

    public void ChangeTapState()
    {
        if (WaterTotalManager.instance.totalWaterUsagePercentage >= 59)
        {
            currState = TapState.Flow;
        }
        else if (WaterTotalManager.instance.totalWaterUsagePercentage > 4)
        {
            currState = TapState.Drip;
        }
        else
        {
            currState = TapState.Dry;
        }
    }
}
