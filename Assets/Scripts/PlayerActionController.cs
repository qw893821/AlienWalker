using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerActionController: MonoBehaviour, IActionController {
    Vector3 targetPos;
    public float speed { get; set; }
    Ray cameraRay;// a ray cast from main camera to mouse 
    NavMeshAgent agent;
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Move();
    }


    public virtual void Move()
    {
        if (Input.GetButton("Fire1"))
        {
            agent.destination = TargetPos();
            Debug.Log("move");
        }
        //agent.destination = targetPos;
    }

    

    public void Attack()
    {

    }
    //get position of mouse on the ground. 
    //currently, when click out of the ground, play will stop moving because the return will be current player pos
    Vector3 TargetPos (){
        Vector3 pos;
        int layermask = 1 << 9;
        RaycastHit hit;
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraRay,out hit,Mathf.Infinity,layermask))
        {
            pos = hit.point;
        }
        else
        {
            pos = transform.position;
        }
        return pos;
    }
}
