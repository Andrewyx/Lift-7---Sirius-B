using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float currentHealth, maxHealth = 3f;
    [SerializeField] private AudioSource DeathSound;
    public float secondsPerAttack = 2;
    public float damageToEngine = 2;
    public float damageToPlayer = 1;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        timer = Time.deltaTime;
                
    }
    public void TakeDamage(float damageAmount) //Paste this function and all its variables into anything that can TAKE DAMAGE
    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
           // if (DeathSound == null) Debug.LogError("Deathsound is null on " + gameObject.name);
            DeathSound.Play();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame

    private void OnCollisionStay2D(Collision2D collision) //Paste if this object can deal damage to something else
    {
        if(collision.gameObject.TryGetComponent<EngineHealth>(out EngineHealth EngineComponent))
        {
            //if (HitSound == null) Debug.LogError("HitSound is null on " + gameObject.name);
            if(timer > secondsPerAttack)
            {
                EngineComponent.TakeDamage(damageToEngine);
                timer = 0;
            }    
            
        }

        if(collision.gameObject.TryGetComponent<PlayerLife>(out PlayerLife PlayerComponent))
        {
            //if (HitSound == null) Debug.LogError("HitSound is null on " + gameObject.name);
            if(timer > secondsPerAttack)
            {
                PlayerComponent.TakeDamage(damageToPlayer);
                timer = 0;
            }    
            
        }
         
    }

    void Update()
    {
        timer += Time.deltaTime; 
    }
}
