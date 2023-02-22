using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health 
{
    
    protected override void OnCollisionEnter(Collision collision)
    {
        if (isDead || collision.gameObject.tag != "EnemyBullet") return;

        currentHealth -= bulletDamage;
        slider.value = currentHealth;

        if (currentHealth <= 0) die();
    }

    protected override void die()
    {
        GameManager.PlayerIsDeath = true;
        isDead = true;
        this.GetComponent<IShooter>().CanFire(false);
        slider.gameObject.SetActive(false);
        anim.SetTrigger("die");
    }
}
