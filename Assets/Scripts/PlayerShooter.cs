using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter,IPoolBullets,IShooter

{
    
    [SerializeField] float fireRate = 0.5F;    
    
    float myTime = 0.0F;
    bool canFire = true;    
    List<GameObject> bullets = new List<GameObject>();
    

    void Start()
    {
        bulletParent = GameObject.FindGameObjectWithTag("Bullets");
        
    }

    void FixedUpdate()
    {
        if(canFire)
        {
            myTime = myTime + Time.deltaTime;

            if (Input.GetButton("Fire1") && myTime > fireRate)
            {
                FireProjectile();
                
                myTime = 0.0F;
            }
        }
        
    }
    protected override void FireProjectile()
    {
        audioSrcGun.Play();
        GameObject newProjectile;
        
        if (bullets.Count == 0 || (bullets.Count > 0 && GetInactiveBullet() == null))
        {
            newProjectile = Instantiate(projectile, cannonGun.transform.position, cannonGun.transform.rotation) as GameObject;
            newProjectile.transform.parent = bulletParent.transform;
            newProjectile.GetComponent<PoolBullet>().speed = speedFire;
            newProjectile.GetComponent<PoolBullet>().shooter = this;
            bullets.Add(newProjectile);

        }
        else 
        {
            newProjectile = GetInactiveBullet();//bullets[bullets.Count -1];
            newProjectile.transform.position = cannonGun.transform.position;
            newProjectile.transform.rotation = cannonGun.transform.rotation;
            newProjectile.SetActive(true);

        }       
       
        newProjectile.transform.parent = bulletParent.transform;

        newProjectile.GetComponent<Rigidbody>().velocity = newProjectile.transform.forward * speedFire;

        
    }

    private GameObject GetInactiveBullet()
    {
        foreach(GameObject bullet in bullets)
        {
            if (bullet.activeSelf == false) return bullet;
        }
        return null;
    }

    

    public void AddBulletPool(GameObject bullet)
    {
        bullets.Add(bullet);
    }

    public void RemoveBulletPool(GameObject bullet)
    {
        bullets.Remove(bullet);
    }

    public void CanFire(bool canFire)
    {
        this.canFire = canFire;
    }
}
