using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyCritter : MonoBehaviour
{
    //Note player var is used for the scoring function, not health tracking
    private GameObject player;

    //health is tracked for the target critter here.
    public int health;
    public int maxHealth;
    public HealthBar healthBar;

    private void Start()
    {
        //for scoring, finding the correct player object
        player = GameObject.Find("Player");
        //setting health for the critter
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            //scoring for the player (commented out in IG2 to get Unity editor to chill)
            //player.GetComponent<PlayerController>().Score += 1;
            //Debug.Log("Score =" + player.GetComponent<PlayerController>().Score);
            
            //managing health for the critter
            TakeDamage(1);
        }

        //when health reaches 0, remove the object from play
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
    
    //custom function that removes the damage returned from total health and updates the healthbar object to the current health
    void TakeDamage (int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }

    /*
        /*WHAT IF instead of DESTROYING an animal after it eats, it turns around to go somewhere else? This ALSO makes the game more fun
       because if the critter turns around and bonks another critter before it gets away it will get spooked and turn back so ya gotta 
       feed it again. This creates a wild ass cloud of bonkin critters you gotta triage and count how many bonks or food they need.

        private void OnTriggerEnter(Collider other)
        {
            transform.Rotate(0, 180, 0); 
        }
       */
}
