using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int startHealth;
    public int currentHealth;
    public int scoreValue = 10;
    public int enemyDef;
    public GameObject alien;
    public GameObject queen;

    bool isDead;

    CapsuleCollider alienCollider;
	// Use this for initialization
	void Awake () {
        alienCollider = GetComponent<CapsuleCollider>();
        
        startHealth = 100;
        currentHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damageNum)
    {
        currentHealth -= (damageNum-enemyDef);
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        alienCollider.isTrigger = true;
        Destroy(gameObject);
    }
}
