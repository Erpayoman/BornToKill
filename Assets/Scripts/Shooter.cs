using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour 
{

	[SerializeField] protected GameObject projectile;
	[SerializeField] protected GameObject cannonGun;
	[SerializeField] protected float speedFire = 10.0f;
	[SerializeField] protected AudioSource audioSrcGun;

	protected GameObject newProjectile;
	protected GameObject bulletParent;

	// Use this for initialization
	void Start () 
	{
		bulletParent = GameObject.FindGameObjectWithTag("Bullets");
	}

	protected abstract void FireProjectile();
}
