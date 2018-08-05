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

    public bool gameStarted = false;

    public enum PersonType{
        Lady,
        Boy,
        FatMan,
        Ouma
    }

    public RuntimeAnimatorController[] animControllers;

    void Start()
    {
        instance = this;
    }

    public void StartGame() {
        gameStarted = true;
        AddPersonToQueue();
        timePassedToAddPersonToQueue = 5;
    }

    void Update()
    {
        if (gameStarted)
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
        TapDisplayManager.instance.DisplayWater();
    }

    public void StopCollecting()
    {
        isCollecting = false;
        people.RemoveAt(0);
        currentCollectingPerson.MoveOffScreen();
        SetCollecter(people[0].GetComponent<PersonBehaviour>());
        SetAllTargetLocations();
        MoveQueueForward();
        TapDisplayManager.instance.DisplayWater();
    }

    public void SetAllTargetLocations()
    {
        if (people.Count >= 1)
        {
            people[0].GetComponent<PersonBehaviour>().SetTargetLocation(new Vector3(tapTransform.localPosition.x + 1600, 0, -20));
            SetCollecter(people[0].GetComponent<PersonBehaviour>());
            for (int i = people.Count - 1; i > 0; i--)
            {
                people[i].GetComponent<PersonBehaviour>().SetTargetLocation(new Vector3(tapTransform.localPosition.x + 1600 - 140 * i, 0, -20));
            }
        }
    }

    public void AddPersonToQueue()
    {
        if (people.Count < 10)
        {
            GameObject newPerson = Instantiate(personPrefab) as GameObject;
            newPerson.transform.SetParent(peopleParent.transform);
            int randType = Random.Range(0, 4);
            newPerson.GetComponent<PersonBehaviour>().Initialize(0);
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

    public RuntimeAnimatorController GetAnimationController(int personType){
        return animControllers[personType];
    }
}
