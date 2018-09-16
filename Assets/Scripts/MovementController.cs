using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController: MonoBehaviour {
    Vector3 targetPos;
    float speed;
	
    public virtual void Movement()
    {
        speed = Speed();
        transform.position = Vector3.MoveTowards(transform.position,targetPos,speed*Time.deltaTime);
    }

    float Speed()
    {
        float calculatedSpeed;
        calculatedSpeed = 0;
        return calculatedSpeed;
    }
}
