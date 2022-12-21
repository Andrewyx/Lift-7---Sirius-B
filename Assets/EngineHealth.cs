using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EngineHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public int maxHealth = 100;
    public int currentHealth;

    private float timer;
    private bool canAttack; //Remove this later
    private int isContact = 0;
    public float iFrames;

    public HealthBar healthBar;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update() 
    {
        timer += Time.deltaTime;
        if(timer > iFrames)
        {
            canAttack = true;
            timer = 0;
        }
        if (isContact > 0 && canAttack)
        {
            EngineTakeDamage(1);
        }   
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        
        if (coll.gameObject.CompareTag("Enemy") && canAttack)
        {
            isContact++;
        }                    
    }
    private void OnCollisionExit2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Enemy") && canAttack)
        {
            isContact--;
        }      
    }

    private void EngineTakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetMaxHealth(currentHealth);
        if (currentHealth <= 0)
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

