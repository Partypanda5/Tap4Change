using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueDisplayManager : MonoBehaviour {
	public static QueueDisplayManager instance;
	
	public List<GameObject> people = new List<GameObject>();
	public GameObject personPrefab;
	public Sprite[] peopleSprites;
	public GameObject peopleParent;

	void Start () {
		instance = this;
	}

	void Update () {

	}	
	public void AddPersonToQueue () {
		GameObject newPerson = Instantiate(personPrefab) as GameObject;
		newPerson.transform.SetParent(peopleParent.transform);
	}
}
