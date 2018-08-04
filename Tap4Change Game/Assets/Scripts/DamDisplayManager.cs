using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamDisplayManager : MonoBehaviour
{

    public static DamDisplayManager instance;

	public GameObject topDamLevel;
	public GameObject midDamLevel;

    void Start()
    {
        instance = this;
    }

	public void ChangeDamLevel() {
		if (WaterTotalManager.instance.totalWaterUsagePercentage >= 59)
		{
			topDamLevel.SetActive(true);
            midDamLevel.SetActive(true);
		}
		else if (WaterTotalManager.instance.totalWaterUsagePercentage > 4)
		{
            topDamLevel.SetActive(false);
            midDamLevel.SetActive(true);
		}
		else
		{
            topDamLevel.SetActive(false);
            midDamLevel.SetActive(false);
		}
	}
}
