using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour 
{
	void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
    
    
	
}
