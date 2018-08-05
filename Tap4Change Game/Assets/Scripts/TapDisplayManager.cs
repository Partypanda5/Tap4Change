using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapDisplayManager : MonoBehaviour
{

    public static TapDisplayManager instance;

    public enum TapState
    {
        Flow,
        Drip,
        Dry
    }

    [SerializeField]
    private GameObject tapWater;

    private TapState currState { get; set; }

    private float targetHeight = 255;
    private bool changeHeight = false;

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

    public void DisplayWater()
    {
        if (tapWater.activeSelf)
        {
            tapWater.SetActive(false);
        }
        else
        {
            tapWater.SetActive(true);
        }
    }
}
