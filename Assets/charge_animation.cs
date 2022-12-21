using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charge_animation : MonoBehaviour
{
    private Animator anim;
    //public Shooting shooting;
    public GameObject myCharging;
    private Shooting myChargingScript;

    void Awake()
    {
        //shooting = player.GetComponent<Shooting>();
        myChargingScript = myCharging.GetComponent<Shooting>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myChargingScript.isCharging)
            anim.SetBool("charge_shot", true);
        else
            anim.SetBool("charge_shot", false);
    }

}
