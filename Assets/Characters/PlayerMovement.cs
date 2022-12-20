using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private AudioSource JumpSoundEffect;
    [SerializeField] private AudioSource WalkSoundEffect;
    private bool canStep;
    private float timer;
    public float timeBetweenSteps;


    //Overhauled Mechanics

    
    private void Start()
    {
        // Old Mechanics

        Debug.Log("Hello, World!"); 
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        
                
    }


    // Old Mechanics
    private void Update()
    {
        float xdirect = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xdirect * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            JumpSoundEffect.Play();
        }
        
        if (!canStep)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenSteps)
            {
                canStep = true;
                timer = 0;
            }
        }        
        
        if (xdirect > 0f && IsGrounded() && canStep)
        {
            anim.SetBool("running_right", true);
            WalkSoundEffect.Play();
            canStep = false;
        }
        else if (xdirect < 0f && IsGrounded() && canStep)
        {
            anim.SetBool("running_left", true);
            WalkSoundEffect.Play();
            canStep = false;
        }
        else if (xdirect == 0)
        {
            anim.SetBool("running_right", false);
            anim.SetBool("running_left", false);
        }

    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    

}
