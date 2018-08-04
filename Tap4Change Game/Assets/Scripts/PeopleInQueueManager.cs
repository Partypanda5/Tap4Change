using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInQueueManager : MonoBehaviour
{
	public static PeopleInQueueManager instance;
	[SerializeField]
    private int targetTimeToFetchWater = 100;
    [SerializeField]
    private int targetTimeToAddPersonToQueue = 100;
    private float timePassedToFetchWater = 0;
	private float timePassedToAddPersonToQueue = 0;

	void Start () {
		instance = this;
	}

    void Update()
    {
		timePassedToAddPersonToQueue += Time.deltaTime;
		timePassedToFetchWater += Time.deltaTime;

		if (timePassedToAddPersonToQueue > targetTimeToAddPersonToQueue) {
			QueueDisplayManager.instance.AddPersonToQueue();
			timePassedToAddPersonToQueue = 0;
		}

		if (timePassedToFetchWater > targetTimeToFetchWater) {
			QueueDisplayManager.instance.RemovePersonFromQueue();
			timePassedToFetchWater = 0;
		}
    }

    public void ChangeTargetTimeToFetchWater()
    {
        if (WaterTotalManager.instance.totalWaterUsagePercentage >= 59)
        {
            targetTimeToFetchWater = 100;
        }
        else if (WaterTotalManager.instance.totalWaterUsagePercentage > 4)
        {
            targetTimeToFetchWater = 130;
        }
        else
        {
            targetTimeToFetchWater = 180;
        }
    }
}
