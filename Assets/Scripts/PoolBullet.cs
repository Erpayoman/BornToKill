using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PoolBullet : MonoBehaviour
{
    public float speed;
    public IPoolBullets shooter;
   
    Rigidbody rigidbody;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        
    }
    public void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);        
        rigidbody.velocity = Vector3.zero;
    }
}
