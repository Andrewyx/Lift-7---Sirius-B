using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EngineHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    private void Update() 
    {
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            //if (DeathSound == null) Debug.LogError("Deathsound is null on " + gameObject.name);
            //Destroy(gameObject);
            //DeathSound.Play();
            RestartLevel();
        }
    }

    private void RestartLevel()
    {  
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(6);
    
    }
}

