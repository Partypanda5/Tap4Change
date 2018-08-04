using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonBehaviour : MonoBehaviour
{

    private Image myImg;
    private RectTransform myTransform;
    [SerializeField]
    private bool isMoving = false;
    [SerializeField]
    private bool isLeaving = false;
    public Vector3 targetLocation;

    public bool isCollecter = false;

    public void Initialize()
    {
        myImg = this.GetComponent<Image>();
        myTransform = this.GetComponent<RectTransform>();
        myTransform.localScale = new Vector3(1, 1, 1);
        myTransform.localPosition = new Vector3(-20, 0, 0);
        targetLocation = myTransform.localPosition;
    }

    void Update()
    {
        if (isMoving)
        {
            MoveForward();
        }
        if (isLeaving)
        {
            myTransform.localPosition = Vector3.MoveTowards(myTransform.localPosition, targetLocation, 10);
        }
    }

    public void MoveForward()
    {
        myTransform.localPosition = Vector3.MoveTowards(myTransform.localPosition, targetLocation, 1);
        if (Vector3.Distance(myTransform.localPosition, targetLocation) < 0.1f)
        {
            isMoving = false;
            if (isCollecter) {
                PeopleInQueueManager.instance.StartCollecting();
            }
        }
    }

    public void MoveOffScreen()
    {
        SetTargetLocation(new Vector3(-100, 0, 0));
        isLeaving = true;
    }

    public void StartMove()
    {
        if (myTransform != null)
        {
            isMoving = true;
        }
    }

    public void SetTargetLocation(Vector3 newTargetLocation)
    {
        targetLocation = newTargetLocation;
    }
}
