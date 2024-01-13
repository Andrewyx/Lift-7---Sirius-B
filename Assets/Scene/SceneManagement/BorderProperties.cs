using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderProperties : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject border = GameObject.FindGameObjectWithTag("Border");     
        Physics2D.IgnoreCollision(border.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
