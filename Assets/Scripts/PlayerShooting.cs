using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public int damageNum;
    public float timeBetweenBullets = 0.15f;
    public float range = 20f;

    float timer;
    Ray shootRay;
    RaycastHit hit;
    int shootableMask;
    LineRenderer gunLine;
    Light gunLight;
    float effectDisplayTime=0.05f;
    int wallMask;

	// Use this for initialization
	void Start () {
        shootableMask = LayerMask.GetMask("Shootable");
        wallMask = LayerMask.GetMask("Block");
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
        damageNum = 10;

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }
        if (timer >= timeBetweenBullets + effectDisplayTime)
        {
            DisableEffect();
        }
		
	}
    public void DisableEffect()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }
    void Shoot()
    {
        timer = 0f;
        gunLight.enabled = true;
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if ((Physics.Raycast(shootRay, out hit, range, shootableMask))|| (Physics.Raycast(shootRay, out hit, range, wallMask)))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageNum);
            }
            gunLine.SetPosition(1, hit.point);
            print(enemyHealth);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

    }

}
