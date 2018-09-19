using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerActionController: MonoBehaviour, IActionController {
    Vector3 targetPos;
    public float speed { get; set; }

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

    Vector3 TargetPos (){
        Vector3 pos;

        pos = Vector3.zero;
        return pos;
    }
}
