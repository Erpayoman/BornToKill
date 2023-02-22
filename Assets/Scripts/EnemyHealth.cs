using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : Health 
{
	SphereCollider enemyRangeCollider;
	NavMeshAgent enemyAIAgent;

    protected override void Start()
    {
        base.Start();
        enemyAIAgent = GetComponent<NavMeshAgent>();
        enemyRangeCollider = GetComponent<SphereCollider>();

    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (isDead || collision.gameObject.tag != "PlayerBullet") return;

        currentHealth -= bulletDamage;
        slider.value = currentHealth;

        if (currentHealth <= 0) die();
    }

    protected override void die()
    {
        enemyAIAgent.enabled = false;//this stop navegation
        enemyRangeCollider.enabled = false;// this stop the detection of the player and the automatic fire
        GameManager.EnemiesAlive--;

        isDead = true;
        this.GetComponent<IShooter>().CanFire(false);
        slider.gameObject.SetActive(false);
        anim.SetTrigger("die");
    }


    
	
	
}
