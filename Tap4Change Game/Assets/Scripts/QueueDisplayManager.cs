using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueDisplayManager : MonoBehaviour
{
    public static QueueDisplayManager instance;

    public List<GameObject> people = new List<GameObject>();
    public GameObject personPrefab;
    public Sprite[] peopleSprites;
    public GameObject peopleParent;

    void Start()
    {
        instance = this;
    }

    void Update()
    {

    }
    public void AddPersonToQueue()
    {
        GameObject newPerson = Instantiate(personPrefab) as GameObject;
        newPerson.transform.SetParent(peopleParent.transform);
        people.Add(newPerson);
    }

    public void RemovePersonFromQueue()
    {
		if (people.Count > 0) {
            if (people.Count > 10)
            {
                GameObject tempPerson = people[0];
                people.Remove(tempPerson);
				tempPerson.GetComponent<PersonBehaviour>().MoveOffScreen();
                Destroy(tempPerson, 10);
            }
            foreach (GameObject person in people)
            {
                person.GetComponent<PersonBehaviour>().StartMove();
            }
		}
    }
}
