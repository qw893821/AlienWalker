using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour {
    public GameObject wallTitle;
    public GameObject queen;
    public GameObject alien;
    public GameObject terrain;
    public GameObject boundary;

    public Transform queenPos;
    Transform alienSpawnPoint;
    float timeCounter;

    private float alienSpawnTime=5f;
    private List<Vector3> queenSpawnPlot = new List<Vector3>();
    private List<Vector3> spawnPosition = new List<Vector3>();

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void SpawnList()
    {
        for(int x=20;x<300; x=x+30)
        {
            for(int z = 20; z < 300; z = z + 40)
            {
                spawnPosition.Add(new Vector3(x, 1f, z));
            }
        }
    }

    Vector3 RandomSpawnPosition()
    {
        int randomIndex = Random.Range(0, spawnPosition.Count);
        Vector3 spawnTrans = spawnPosition[randomIndex];
        spawnPosition.RemoveAt(randomIndex);
 
        return spawnTrans;
    }

    void SpawnWall()
    {
        int wallCount = (int)Random.Range(15, 20);
        for(int i = 0; i < wallCount; i++)
        {
            Vector3 randomSpawnPosition=RandomSpawnPosition();
            Instantiate(wallTitle,randomSpawnPosition,Quaternion.identity);
        }
    }



    public void SpawnQueen()
    {
        int randomIndex = Random.Range(0, spawnPosition.Count);
        Vector3 spawnTrans = spawnPosition[randomIndex];
        Instantiate(queen, spawnTrans, Quaternion.identity);
    }

    public void WallSpawn()
    {
        SpawnList();
        SpawnWall();
    }

    public void SpawnAlien(int level)
    {
       timeCounter += Time.deltaTime;
       if (timeCounter >= alienSpawnTime) { 
           Instantiate(alien, queenPos.position+new Vector3(10,0,10), transform.rotation);
           timeCounter = 0f;
       }
        //print(queenPos.position);
    }
    public void CreateTerrain()
    {
        Instantiate(terrain, new Vector3(0, 0, 0),Quaternion.identity);
    }
    public void CreateBoundary()
    {
        Instantiate(boundary, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
