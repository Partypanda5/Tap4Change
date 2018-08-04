using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightDisplayManager : MonoBehaviour {

int systemHour = System.DateTime.Now.Hour;


	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
	
	 if(systemHour >= 6 && systemHour <= 17)
	 {
    	 Debug.Log("Good Morning/Afternoon!");
		
	 }

	 if ((systemHour >= 0 && systemHour <= 5) || (systemHour >= 18)){

		  Debug.Log("Good Evening!");

		  //do stuff with sprite to make it night

	 }




	}
}
