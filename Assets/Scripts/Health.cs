using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public abstract class Health : MonoBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] protected int maxHealth = 100;    
    [SerializeField] protected int bulletDamage = 10;

    protected bool isDead = false;

    public int MaxHealth { get { return maxHealth; } }
    public bool IsDead  { get { return isDead; } }


    protected int currentHealth;
    protected bool isEnemy = false;
    protected Animator anim;
   
    protected virtual void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();        
        
    }

    protected abstract void OnCollisionEnter(Collision collision);
    
    protected abstract void die();
   
    public void setCurrentHealth(int health)
    {
        currentHealth = health;
        slider.value = currentHealth;
    }
}
