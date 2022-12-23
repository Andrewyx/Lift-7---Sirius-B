using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondShotScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    public float force;
    public float diamondDamage = 1;    
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); 

        Vector3 direction =player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); //track screensize
        
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");     
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());    
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x < screenBounds.x * -2 || transform.position.x > screenBounds.x * 2){
            Destroy(this.gameObject);
        }
        else if(transform.position.y < screenBounds.y * -2 ||transform.position.y > screenBounds.y * 2 )
        {
            Destroy(this.gameObject);
        }        
                
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.TryGetComponent<PlayerLife>(out PlayerLife PlayerComponent))
        {
            //HitSound.Play();
            PlayerComponent.TakeDamage(diamondDamage);
            CinemachineShake.Instance.ShakeCameraSharp(2f, 0.1f);
        }
        
        else if(collision.gameObject.TryGetComponent<EngineHealth>(out EngineHealth EngineHealthComponent))
        {
            //HitSound.Play();
            EngineHealthComponent.TakeDamage(diamondDamage);
            CinemachineShake.Instance.ShakeCameraSharp(2f, 0.1f);
        }
        Destroy(gameObject);         
    }    
}
