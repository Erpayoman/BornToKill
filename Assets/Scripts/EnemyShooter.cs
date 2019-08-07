using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour,Shooter
{
   
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject cannonGun;
    [SerializeField] float speed = 10.0f;
    [SerializeField] AudioSource audioSrcGun;
   
    GameObject newProjectile;    
    GameObject bulletParent;

    private void Awake()
    {
        bulletParent = GameObject.FindGameObjectWithTag("Bullets");
    }
       
   
    private void FireProjectile()
    {

        audioSrcGun.Play();

        newProjectile = Instantiate(projectile, cannonGun.transform.position, cannonGun.transform.rotation) as GameObject;
        newProjectile.transform.parent = bulletParent.transform;

        newProjectile.GetComponent<Rigidbody>().velocity = newProjectile.transform.forward * speed;

        Destroy(newProjectile, 2.5f);
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
