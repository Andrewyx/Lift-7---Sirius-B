using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] private AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
                
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <=0)
        {
           // if (DeathSound == null) Debug.LogError("Deathsound is null on " + gameObject.name);
            Destroy(gameObject);
            //DeathSound.Play();
        }
    }
    // Update is called once per frame
    void Update()
    { 
    }
}
