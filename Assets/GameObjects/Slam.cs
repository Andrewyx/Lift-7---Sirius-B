using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : MonoBehaviour
{
    // Start is called before the first frame update
    public float blockDuration;
    public float blockInterval = 10f;
    public float blockAngleInDegrees = 20f;
    public Transform rotatePoint;

    private float timer;
    private bool isBlocking = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
        timer += Time.deltaTime;
        if(timer > blockInterval && !isBlocking)
        {    
            //for (int i = 0; i < blockAngleInDegrees; i += 3 )
            //{
        transform.RotateAround(rotatePoint.position, Vector3.forward, blockAngleInDegrees);
            //}   
            timer = 0;       
        
        }
        //else if(timer > blockDuration && isBlocking)
        //{
            //for (int x = blockAngleInDegrees; x > 0; x -= 3 )
            //{

                
            
            timer = 0;
            //}                      
        //}
    
    }
}
