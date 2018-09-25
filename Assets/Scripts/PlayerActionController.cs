using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum Action{
    idle,
    walk,
    run,
    attack
}
public class PlayerActionController: MonoBehaviour, IActionController {
    Vector3 targetPos;
    public float speed { get; set; }
    public Action act { get; set; }
    AnimationController ac;
    Ray cameraRay;// a ray cast from main camera to mouse 
    NavMeshAgent agent;

    //double click timer
    public float doubleClickTimer;
    public float doubleClickTime;
    bool isSingle;
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        ac = transform.GetComponent<AnimationController>();
        doubleClickTimer = 0f;
        isSingle = false;
    }
    void Update()
    {
        Move();
        AnimationChanger();
        if (transform.position == agent.destination)
        {
            act = Action.idle;
        }

        //temp code
        
    }


    public virtual void Move()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //act = Action.walk;
            act=WalkRunSwitcher();
            agent.destination = TargetPos();
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

    void AnimationChanger()
    {
        switch (act){
            case Action.idle:
                ac.idle = true;
                ac.walk = false;
                ac.run = false;
                break;
            case Action.walk:
                ac.idle = false;
                ac.walk = true;
                ac.run = false;
                break;
            case Action.run:
                ac.idle = false;
                ac.walk = false;
                ac.run = true;
                break;
            default:
                ac.idle = true;
                ac.walk = false;
                ac.run = false;
                break;
        }
    }

    //have some issue
    Action WalkRunSwitcher()
    {
        //a precheck if the timer have exceed the setted double check time
        if (doubleClickTimer > doubleClickTime)
        {
            isSingle = false;
            StopCoroutine(DoubleClickTimer());
            doubleClickTimer = 0;
        }
        //if (Input.GetButton("Fire1")) {
        if (!isSingle)
        {
            StartCoroutine(DoubleClickTimer());
            isSingle = true;
            Debug.Log("walk");
            return Action.walk;
        }
        else 
        {
            //StopCoroutine(DoubleClickTimer());
            doubleClickTimer = 0;
            isSingle = false;
            Debug.Log("run");
            return Action.run;
        }
        //}

    }

    IEnumerator DoubleClickTimer()
    {
        doubleClickTimer += Time.deltaTime;
        yield return new WaitForSeconds(0.016f);
        DoubleClickTimer();
        yield return null;
    }
}
