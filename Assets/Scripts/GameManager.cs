using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    /*public SpawnManger wall;
    public SpawnManger queen;
    public SpawnManger alien;
    public SpawnManger terrain;*/

    SpawnManger wall;
    SpawnManger queen;
    SpawnManger alien;
    SpawnManger terrain;
    SpawnManger boundary;
    GameObject newQueen;

    // Use this for initialization
    void Start () {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        wall = GetComponent<SpawnManger>();
        queen = GetComponent<SpawnManger>();
        alien = GetComponent<SpawnManger>();
        terrain = GetComponent<SpawnManger>();
        boundary = GetComponent<SpawnManger>();
        InitGame();
	}
	
    void InitGame()
    {
        wall.WallSpawn();
        queen.SpawnQueen();
        terrain.CreateTerrain();
        boundary.CreateBoundary();
        newQueen = GameObject.FindGameObjectWithTag("Queen");
    }
	// Update is called once per frame
	void Update () {
        alien.queenPos = newQueen.transform;
        alien.SpawnAlien(1);
        print(alien.queenPos);
    }
}
