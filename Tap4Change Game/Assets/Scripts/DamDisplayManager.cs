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
			topDamLevel.GetComponent<Image>().CrossFadeAlpha((WaterTotalManager.instance.totalWaterUsagePercentage - 41)*0.59f, 0.1f, false);
			topDamLevel.SetActive(true);
            midDamLevel.SetActive(true);
		}
		else if (WaterTotalManager.instance.totalWaterUsagePercentage > 4)
		{
            midDamLevel.GetComponent<Image>().CrossFadeAlpha((WaterTotalManager.instance.totalWaterUsagePercentage - 4) * 0.55f, 0.1f, false);
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
