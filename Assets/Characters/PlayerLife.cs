using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image[] hearts;
    [SerializeField] private charge_animation _charge;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 screenBounds;
    public GameObject player;
    public float maxHealth = 100;
    public float currentHealth;
    public float timer;
    public float deathScreenTime = 100;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        UpdateHealth();
    }

    void Update()
    {
        if(transform.position.x < screenBounds.x * -2 || transform.position.x > screenBounds.x * 2){
            RestartLevel();
        }
        else if(transform.position.y < screenBounds.y * -2)
        {
            RestartLevel();
        }        
    }

    public void TakeDamage(float damageAmount) //Paste this function and all its variables into anything that can TAKE DAMAGE
        {
            currentHealth -= damageAmount;
            if(currentHealth > 0)
            {
                UpdateHealth();
            }
            if(currentHealth <= 0)
            {
                // if (DeathSound == null) Debug.LogError("Deathsound is null on " + gameObject.name);
                //DeathSound.Play();
                rb.bodyType = RigidbodyType2D.Static;
                anim.SetTrigger("dwarf_death");      
                _charge.getDestroyed();
            }
        }

    private void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].color = Color.white;
            }

            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    private void RestartLevel()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

