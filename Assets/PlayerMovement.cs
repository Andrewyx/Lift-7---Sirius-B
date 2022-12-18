using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigbod;
    
    
    private void Start()
    {
        Debug.Log("Hello, World!"); 
        rigbod = GetComponent<Rigidbody2D>();
                
    }

    // Update is called once per frame
    private void Update()
    {
        float xdirect = Input.GetAxisRaw("Horizontal");
        rigbod.velocity = new Vector2(xdirect * 8f, rigbod.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
            rigbod.velocity = new Vector3(rigbod.velocity.x,  15f, 0);
        }
        
    }
}
