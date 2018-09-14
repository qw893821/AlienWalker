using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    //enemy dps ability
    public int damagePower;
    public float timeBetweenAttack;

    //gameobject needed in this class
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    //only attack player in enemies' range
    bool playerInRange;
    //conculate time after attack
    float timeCounter;
	// Use this for initialization

	void Start () {
        damagePower = 5;
        timeBetweenAttack = 0.5f;
        playerHealth = GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //timeCounter += Time.deltaTime;
        //if ((timeCounter >= timeBetweenAttack) && playerInRange && (enemyHealth.currentHealth > 0))
        //{
            Attack();
        // }
        print(playerHealth.currentHealth);
    }
    //player enters enemy's attack range
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    //player out of enemy's attack range
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timeCounter += Time.deltaTime;
        if ((timeCounter >= timeBetweenAttack)&&playerInRange&&(enemyHealth.currentHealth>0))
        {
            if (playerHealth.currentHealth > 0)
            {
                playerHealth.GetDamage(damagePower);
                timeCounter = 0f;
            }
        }
        /*timeCounter = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.GetDamage(damagePower);
        }*/
    }
}
