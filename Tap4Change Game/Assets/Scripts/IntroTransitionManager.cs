using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTransitionManager : MonoBehaviour {

	public GameObject overlayPanel;

	public Sprite intro1;	
	public Sprite intro2;	
	public Sprite intro3;	

	// Use this for initialization
	void Start () {

	overlayPanel.GetComponent<Image>().sprite = intro1;
		
	}
	
	// Update is called once per frame
	void Update () {

		 if(Input.GetMouseButtonDown(0)){

			 if (overlayPanel.GetComponent<Image>().sprite == intro1)
				 overlayPanel.GetComponent<Image>().sprite = intro2;


		   else if (overlayPanel.GetComponent<Image>().sprite == intro2)
			   	 overlayPanel.GetComponent<Image>().sprite = intro3;

		   }
		
	}
}
