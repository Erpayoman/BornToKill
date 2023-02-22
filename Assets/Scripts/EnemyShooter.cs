using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Shooter,IShooter
{
   
    private void Awake()
    {
        bulletParent = GameObject.FindGameObjectWithTag("Bullets");
    }      
   
    protected override void FireProjectile()
    {

        audioSrcGun.Play();        
        
        newProjectile = Instantiate(projectile, cannonGun.transform.position, cannonGun.transform.rotation) as GameObject;
        newProjectile.transform.parent = bulletParent.transform;         
            
        
        newProjectile.transform.parent = bulletParent.transform;

        newProjectile.GetComponent<Rigidbody>().velocity = newProjectile.transform.forward * speedFire;
    }
    
    //Only shoot when the player is near 
    private void OnTriggerEnter(Collider other)
    {
               
        if (other.gameObject.tag != "Player") return;
        CanFire(true);       

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        CanFire(false);
    }
    public void CanFire(bool canFire)
    {
       if(canFire)
        {
            float randonShootRate = Random.Range(0.2f, 0.9f);//Introduce a random value for the speed in the shooting

            InvokeRepeating("FireProjectile", 0.1f, randonShootRate);
        }
       else
        {
            CancelInvoke();
        }
    }

   
    
}
