using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    //player health related status;
    public int startHealth;
    public int currentHealth;
    public int armorPoint;
    public int currentArmorPoint;

    PlayerShooting playerShooting;
    PlayerMovementController playerMovement;

    bool getDamage;
    bool isDeath;   //player die
	// Use this for initialization
	void Awake () {
        playerShooting = GetComponent<PlayerShooting>();
        startHealth = 100;
        currentHealth = startHealth;
        armorPoint = 0;
        currentArmorPoint = armorPoint;
	}
	
	// Update is called once per frame
	void Update () {
        getDamage = false;
        print(currentHealth);
	}

    public void GetDamage(int damageNum)
    {
        getDamage = true;
        if (currentArmorPoint > 0)//check if player have armor point
        { 
            if (currentArmorPoint >=damageNum)//armor point is more than damage power,then reduce armor point
            {
                currentArmorPoint -= damageNum;
            }
            else//few armor, cause damage to player health
            {
                currentHealth = currentHealth + currentArmorPoint - damageNum;
                currentArmorPoint = 0;
            }
        }
        else
        {
            currentHealth -=damageNum;
        }
        //currentHealth -= damageNum;
        if (currentHealth <= 0&&!isDeath)
        {
            Death();
        }
    }

    void Death()
    {
        isDeath = true;
        playerShooting.DisableEffect();
        playerShooting.enabled = false;
        playerMovement.enabled = false;

    }
}
