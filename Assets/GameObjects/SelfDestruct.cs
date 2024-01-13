using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float Lifetime = 2;
    private float timer;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= Lifetime)
        {
            Destroy(gameObject);
        }
    }
}
