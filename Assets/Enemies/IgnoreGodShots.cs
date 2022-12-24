using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreGodShots : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject godbullet = GameObject.FindGameObjectWithTag("GodBullet");     
        Physics2D.IgnoreCollision(godbullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
