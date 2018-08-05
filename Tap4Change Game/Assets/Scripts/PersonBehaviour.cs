using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonBehaviour : MonoBehaviour
{

    public PeopleInQueueManager.PersonType myType;
    private RectTransform myTransform;
    [SerializeField]
    private bool isMoving = false;
    [SerializeField]
    private bool isLeaving = false;

    public bool isCollecting = false;
    [SerializeField]
    private Animator myAnim; 


    public Vector3 targetLocation;

    public bool isCollecter = false;

    private float maxMovement = 10;

    public void Initialize(PeopleInQueueManager.PersonType newType)
    {
        myType = newType;
        myAnim.runtimeAnimatorController = PeopleInQueueManager.instance.GetAnimationController((int)newType);
        myTransform = this.GetComponent<RectTransform>();
        myTransform.localScale = new Vector3(80, 80, 80);
        myTransform.localPosition = new Vector3(-20, 0, -20);
        targetLocation = myTransform.localPosition;
        maxMovement = Random.Range(0.9f, 1);
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
        myTransform.localPosition = Vector3.MoveTowards(myTransform.localPosition, targetLocation, maxMovement);
        if (Vector3.Distance(myTransform.localPosition, targetLocation) < 0.1f)
        {
            isMoving = false;
            if (isCollecter) {
                PeopleInQueueManager.instance.StartCollecting();
                ChangeAnimationState(0);
            } else {
                ChangeAnimationState(1);
            }
        }
    }

    public void MoveOffScreen()
    {
        SetTargetLocation(new Vector3(-100, 0, -20));
        isLeaving = true;
        ChangeAnimationState(2);
        Destroy(this.gameObject, 5);
        myTransform.Rotate(0, 180, 0);
    }

    public void StartMove()
    {
        if (myTransform != null)
        {
            isMoving = true;
            ChangeAnimationState(2);
        }
    }

    public void SetTargetLocation(Vector3 newTargetLocation)
    {
        targetLocation = newTargetLocation;
    }

    public void ChangeAnimationState(int state)
    {
        if (state == 0) {
            myAnim.SetBool("isCollecting", true);
            myAnim.SetBool("isWalking", false);
        }
        else if (state == 1) {
            myAnim.SetBool("isCollecting", false);
            myAnim.SetBool("isWalking", false);
        }
        else if (state == 2) {
            myAnim.SetBool("isCollecting", false);
            myAnim.SetBool("isWalking", true);
        }
    }
}
