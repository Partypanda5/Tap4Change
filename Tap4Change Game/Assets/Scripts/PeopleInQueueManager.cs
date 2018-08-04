using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInQueueManager : MonoBehaviour
{
    public static PeopleInQueueManager instance;
    public int targetTimeToFetchWater = 1;
    private float timePassedFetchingWater = 0;

    [SerializeField]
    private int targetTimeToAddPersonToQueue = 100;
    private float timePassedToAddPersonToQueue = 0;

    public bool isCollecting = false;
    public PersonBehaviour currentCollectingPerson;

    public List<GameObject> people = new List<GameObject>();
    public GameObject personPrefab;
    public Sprite[] peopleSprites;
    public GameObject peopleParent;
    public RectTransform tapTransform;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (isCollecting)
        {
            timePassedFetchingWater += Time.deltaTime;
            if (timePassedFetchingWater > targetTimeToFetchWater)
            {
                StopCollecting();
            }
        }

        timePassedToAddPersonToQueue += Time.deltaTime;

        if (timePassedToAddPersonToQueue > targetTimeToAddPersonToQueue)
        {
            AddPersonToQueue();
            timePassedToAddPersonToQueue = 0;
        }
    }

    public void SetCollecter(PersonBehaviour currPerson)
    {
        currentCollectingPerson = currPerson;
        currentCollectingPerson.isCollecter = true;
    }

    public void StartCollecting()
    {
        isCollecting = true;
        timePassedFetchingWater = 0;
    }

    public void StopCollecting()
    {
        isCollecting = false;
        people.RemoveAt(0);
        currentCollectingPerson.MoveOffScreen();
        SetCollecter(people[0].GetComponent<PersonBehaviour>());
        SetAllTargetLocations();
        MoveQueueForward();
    }

    public void SetAllTargetLocations()
    {
        if (people.Count >= 1)
        {
            people[0].GetComponent<PersonBehaviour>().SetTargetLocation(new Vector3(tapTransform.localPosition.x + 500, 0, 0));
            SetCollecter(people[0].GetComponent<PersonBehaviour>());
            for (int i = people.Count - 1; i > 0; i--)
            {
                people[i].GetComponent<PersonBehaviour>().SetTargetLocation(new Vector3(tapTransform.localPosition.x + 500 - 60*i, 0, 0));
            }
        }
    }

    public void AddPersonToQueue()
    {
        if (people.Count < 19) {
            GameObject newPerson = Instantiate(personPrefab) as GameObject;
            newPerson.transform.SetParent(peopleParent.transform);
            newPerson.GetComponent<PersonBehaviour>().Initialize();
            people.Add(newPerson);
            SetAllTargetLocations();
            newPerson.GetComponent<PersonBehaviour>().StartMove();
        }
    }

    public void MoveQueueForward()
    {
        foreach (GameObject person in people)
        {
            person.GetComponent<PersonBehaviour>().StartMove();
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
