using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour,Shooter
{
    
    public GameObject projectile;
    public GameObject cannonGun;
    public float fireDelta = 0.5F;
    public float speed = 10.0f;
    public AudioSource audioSrcGun;

    float nextFire = 0.5F;
    GameObject newProjectile;
    float myTime = 0.0F;
    bool canFire = true;
    GameObject bulletParent;
    

    void Start()
    {
        bulletParent = GameObject.FindGameObjectWithTag("Bullets");
        
    }

    void FixedUpdate()
    {
        if(canFire)
        {
            myTime = myTime + Time.deltaTime;

            if (Input.GetButton("Fire1") && myTime > nextFire)
            {
                FireProjectile();

                nextFire = fireDelta;
                myTime = 0.0F;
            }
        }
        
    }
    private void FireProjectile()
    {
        audioSrcGun.Play();
        newProjectile = Instantiate(projectile, cannonGun.transform.position, cannonGun.transform.rotation) as GameObject;
        newProjectile.transform.parent = bulletParent.transform;

        newProjectile.GetComponent<Rigidbody>().velocity = newProjectile.transform.forward * speed;

        Destroy(newProjectile, 2f);
    }
    public void CanFire(bool value)
    {
        canFire = value;
    }
}
