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

    public Sprite[] tapSprites;

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
            tapWater.GetComponent<Image>().sprite = tapSprites[0];
        }
        else if (WaterTotalManager.instance.totalWaterUsagePercentage > 4)
        {
            currState = TapState.Drip;
            tapWater.GetComponent<Image>().sprite = tapSprites[1];
        }
        else
        {
            currState = TapState.Dry;
        }
    }

    public void DisplayWater () {
        if (tapWater.activeSelf) {
            tapWater.SetActive(false);
        }
        else {
            tapWater.SetActive(true);
        }
    }
}
