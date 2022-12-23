using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenryShoot : MonoBehaviour
{
    public GameObject diamondShot;
    public Transform diamondPos;


    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            timer = 0;
            shootDiamond();
        }

    }
    private void shootDiamond()
    {
        Instantiate(diamondShot, diamondPos.position, Quaternion.identity);
    }

}
