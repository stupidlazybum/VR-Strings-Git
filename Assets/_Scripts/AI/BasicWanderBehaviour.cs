using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BasicWanderBehaviour : MonoBehaviour {

    public float baseMoveSpeed;
    public float speedVariationRange;
    public float turnInterval;

    public bool canMove;
    public bool isMoving;

    private Vector3 randomDestination;
    private float newSpeed;
    private float timeSinceLastTurn;

    private VRTK_InteractableObject thisGrabbableObj;


	// Use this for initialization
	void Start () {
        thisGrabbableObj = GetComponent<VRTK_InteractableObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (thisGrabbableObj.IsGrabbed())
        {
            canMove = false;
        }

        else
        {
            canMove = true;
        }

        if (canMove && !isMoving)
        {
            //pick a random direction
            randomDestination = new Vector3(Random.value, Random.value, Random.value);

            //set random speed based on variation range
            newSpeed = baseMoveSpeed + Random.Range(-speedVariationRange, speedVariationRange);

            isMoving = true;


        }

        if (timeSinceLastTurn < turnInterval && canMove && isMoving)
        {


            //move in that direction at that speed
            this.transform.position = Vector3.Lerp(this.transform.position, randomDestination, Time.deltaTime * newSpeed);

            //wait for time = turn interval
            timeSinceLastTurn += Time.deltaTime;

            //repeat
        }

        if (timeSinceLastTurn > turnInterval)
        {
            timeSinceLastTurn = 0f;
            isMoving = false;
        }

    }
}
