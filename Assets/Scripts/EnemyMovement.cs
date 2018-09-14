using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    //public GameObject blockWall;
    float speed;
    int wallMask;
    float timeCounter;
    Ray navRay;
    RaycastHit hit;
    //Vector3 targetPos;
    Vector3 directPos;
    Vector3 circularPos;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = 10f;
        wallMask = LayerMask.GetMask("Block");
        timeCounter = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
        print(circularPos);
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    void EnemyMove() {
        navRay.origin = transform.position;
        navRay.direction = player.position-transform.position;
        if ((Physics.Raycast(navRay,out hit,20f,wallMask))&&(Vector3.Distance(transform.position,hit.transform.position)<=15))
         {
            float radius = 15f;
            /*timeCounter += Time.deltaTime;
            float x = hit.transform.position.x+Mathf.Cos(timeCounter) * radius;
            float y = hit.transform.position.y;
            float z = hit.transform.position.z+Mathf.Sin(timeCounter) * radius;
            circularPos = new Vector3(x, y, z);*/
            float cornerAngle=2f*Mathf.PI/(float)(2f*Mathf.PI*radius/speed);
            Vector3 currentPoint= new Vector3(Mathf.Cos(cornerAngle) * radius, transform.position.y, Mathf.Sin(cornerAngle) * radius);
            circularPos = hit.transform.position+currentPoint;
            transform.position = Vector3.MoveTowards(transform.position, circularPos, speed * Time.deltaTime);
        }
        else
        {
            DirectMove();
        }


    }
    void DirectMove()
    {
        directPos = player.position;
        transform.position = Vector3.MoveTowards(transform.position, directPos, speed * Time.deltaTime);
        timeCounter = 0f;

    }

}
