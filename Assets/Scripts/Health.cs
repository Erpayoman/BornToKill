using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 100;
    
    public int bulletDamage = 10;
    public bool isdeath = false;


    int currentHealth;
    bool isEnemy = false;
    Animator anim;
    SphereCollider EnemyCollider;
    NavMeshAgent enemyAIAgent;
    Shooter shooter;
    
    

   
    private void Start()
    {
        isEnemy = (this.tag == "Player") ? false : true;

        if (isEnemy)
        {
            enemyAIAgent = GetComponent<NavMeshAgent>();
            EnemyCollider = GetComponent<SphereCollider>();

        }

        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        shooter = GetComponent<Shooter>();
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (isdeath) return;

        if (collision.gameObject.tag != "PlayerBullet" && collision.gameObject.tag != "EnemyBullet") return;

        if((isEnemy && collision.gameObject.tag == "PlayerBullet")|| (!isEnemy && collision.gameObject.tag == "EnemyBullet"))
        {
            currentHealth -= bulletDamage;
            slider.value = currentHealth;
        }

        if (currentHealth <= 0) die();


    }
    private void die()
    {
        if(isEnemy)
        {
            enemyAIAgent.enabled = false;//this stop navegation
            EnemyCollider.enabled = false;// this stop the detection of the player and the automatic fire
            GameManager.EnemiesAlive--;
        }
        else
        {
            GameManager.PlayerIsDeath = true;
        }
        

        isdeath = true;
        shooter.CanFire(false);
        slider.gameObject.SetActive(false);
        anim.SetTrigger("die");        


    }
    public void setCurrentHealth(int health)
    {
        currentHealth = health;
        slider.value = currentHealth;
    }
}
