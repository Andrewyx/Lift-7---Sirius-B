using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float timer;
    [SerializeField] private float blockDurationCounter;
    [SerializeField] private float timeSinceLastBlock;
    public Transform rotatePoint;
    public GameObject arms;
    private Transform initArmsTransforms;
    public float totalBlockDuration = 4.0f;
    public float blockAngleInDegrees = 50f;
    public float blockRestDuration = 5f;
    public float unblockRate = 1.5f;
    public float unblockDuration = 2.0f;
    public float blockRate = 1.5f;
    public float blockDuration = 2.0f;
    [SerializeField] private string state = "REST";

    private float timeSinceBlockStart;

    void Start()
    {
        initArmsTransforms = arms.transform;
        blockDurationCounter = blockDuration;
    }

    // Update is called once per frame
    void Update()
    {
        /* Slam Purpose 
        Produces Slam animation for Henry's Arms 
        Class should: 
        - Raise arms after given rest interval where arms are down
        - Raise arms in specificied amount of time -> rotation rate should be privately calculated
        - Arms should be raised for the block duration (counting the raising/unraise animaations)
        - Arms should then unblock across given duration
        - Function then enters rest state for the given block interval

        Good to haves:
        - Randomize block duration & intervals 
        
        */

        switch (state)
        {
            case "REST":
                // arms.transform.Translate(initArmsTransforms.position);
                // arms.transform.Rotate(initArmsTransforms.rotation.eulerAngles, Space.Self);
                timeSinceLastBlock += Time.deltaTime;
                if (timeSinceLastBlock >= blockRestDuration)
                {
                    state = "RAISEARM";
                    timeSinceLastBlock = 0;
                    resetRaiseArm();
                }
                break;
                
            case "RAISEARM":
                blockDurationCounter += Time.deltaTime;
                timeSinceBlockStart += Time.deltaTime;
                RotateArmForward(blockRate, CalculateRotationRate(blockAngleInDegrees, blockDuration));
                if (blockDurationCounter >= blockDuration)
                {
                    blockDurationCounter = 0;
                    state = "BLOCK";
                }
                break;

            case "BLOCK":
                timeSinceBlockStart += Time.deltaTime;
                if (timeSinceBlockStart >= (BlockTime() + blockDuration)) {
                    state = "LOWERARM";
                    blockDurationCounter = 0;
                    
                }
                break;

            case "LOWERARM":
                blockDurationCounter += Time.deltaTime;
                timeSinceBlockStart += Time.deltaTime;
                RotateArmBack(unblockRate, CalculateRotationRate(blockAngleInDegrees, unblockDuration));
                if (blockDurationCounter >= unblockDuration) {
                    timeSinceBlockStart = 0;
                    state = "REST";
                }
                break;
        }
    }
    private float BlockTime() {
        float blockUptime = totalBlockDuration - (blockDuration + unblockDuration);
        if (blockUptime > 0) {
            return blockUptime;
        }
        else {
            Debug.Log("Error, totalBlockDuration cannot be less than blockDuration + unblockDuration, defaulted to 1");
            return 1f;
        }
    }
    private void resetRaiseArm()
    {
        blockDurationCounter = 0;
        timeSinceBlockStart = 0;
    }

    private float CalculateRotationRate(float totalAngle, float totalDuration)
    {
        // Angular speed in Degrees per second
        return totalAngle / totalDuration;
    }

    private void RotateArmForward(float forwardRate, float rotationRate)
    {
        //Raises arms to block
        arms.transform.RotateAround(rotatePoint.position, Vector3.forward, -(forwardRate * rotationRate * Time.deltaTime));
    }
    private void RotateArmBack(float backwardsRate, float rotationRate)
    {
        //Lowers arms from block
        arms.transform.RotateAround(rotatePoint.position, Vector3.forward, backwardsRate * rotationRate * Time.deltaTime);
    }
}
