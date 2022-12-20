using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
    }
    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Die();
            RestartLevel();
        }
             
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetBool("dwarf_death", true);        
    }
    private void RestartLevel()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

