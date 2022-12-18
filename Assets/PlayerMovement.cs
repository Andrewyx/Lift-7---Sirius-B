using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigbod;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 15f;

    
    private void Start()
    {
        Debug.Log("Hello, World!"); 
        rigbod = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

                
    }

    // Update is called once per frame
    private void Update()
    {
        float xdirect = Input.GetAxisRaw("Horizontal");
        rigbod.velocity = new Vector2(xdirect * moveSpeed, rigbod.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigbod.velocity = new Vector3(rigbod.velocity.x, jumpForce, 0);
        }
        
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
