using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    public float speed;
    Vector3 direction;
    Rigidbody playerRigidbody;
    public Vector3 size;
    float camRayLength;
    int floorMask;
	// Use this for initialization
	void Awake () {
        //GameObject terrain = GameObject.FindGameObjectWithTag("Terrain");
        camRayLength = 150f;
        floorMask = LayerMask.GetMask("Floor");
        speed = 3.0f; //player speed;
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.transform.position = new Vector3(Random.Range(50.0f, 250.0f), 1f, Random.Range(50, 250f));//random spawn, need fix. where there is a blcok, player could not spawn.
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
	}

    void Move(float h,float v)//player move by useing input
    {
        direction = new Vector3(h, 0f, v);
        transform.position=transform.position + direction.normalized * speed * Time.deltaTime;
        playerRigidbody.position = playerRigidbody.position + direction.normalized * speed * Time.deltaTime;
    }
    void Turning()//let player turn around following mouse direction
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if(Physics.Raycast(camRay,out floorHit, camRayLength, floorMask))
        {
            Vector3 playerMouse = floorHit.point - transform.position;
            playerMouse.y = 0.5f;

            Quaternion newRotation = Quaternion.LookRotation(playerMouse);

            playerRigidbody.MoveRotation(newRotation);
        }
        

    }
}
