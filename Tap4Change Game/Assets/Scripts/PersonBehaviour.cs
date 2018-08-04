using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonBehaviour : MonoBehaviour
{

    private Image myImg;
	private RectTransform myTransform;

    private bool isMoving = false;
    private bool isLeaving = false;
    private Vector3 targetLocation;
    void Start()
    {
        myImg = this.GetComponent<Image>();
		myTransform = this.GetComponent<RectTransform>();
		myTransform.localScale = new Vector3(1, 1, 1);
        myTransform.localPosition = new Vector3(0, 0, 0);
        targetLocation = myTransform.localPosition;
    }

    void Update()
    {
        if (isMoving) {
            MoveForward();
        }
        if (isLeaving) {
            myTransform.localPosition = Vector3.MoveTowards(myTransform.localPosition, new Vector3(-10, 0, 0), 10);
        }
    }

	public void MoveForward() {
		myTransform.localPosition = Vector3.MoveTowards(myTransform.localPosition, targetLocation, 1);
        if (Vector3.Distance(myTransform.localPosition, targetLocation) < 0.1f){
            isMoving = false;
        } 
	}

    public void MoveOffScreen() {
        isLeaving = true;
    }

    public void StartMove() {
    if (myTransform != null)
        targetLocation = myTransform.localPosition + new Vector3(75, 0, 0);
        isMoving = true;
    }
}
