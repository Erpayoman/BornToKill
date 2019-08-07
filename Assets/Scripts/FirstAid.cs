using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    [SerializeField] AudioClip rewardSound;
    [SerializeField] float volumeFX;

    private void OnTriggerEnter(Collider other)
    {
        // when the pack is picked up the health for the player is set to maximum and the pack dissapears
        if(other.tag == "Player")
        {
            Debug.Log("reload");
            Health health = other.gameObject.GetComponent<Health>();
            health.setCurrentHealth(health.maxHealth);
            AudioSource.PlayClipAtPoint(rewardSound, this.transform.position,volumeFX);
            gameObject.SetActive(false);
            
        }
    }

}
