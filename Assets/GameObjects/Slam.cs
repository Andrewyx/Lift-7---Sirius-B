using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Slam : MonoBehaviour
{
    // Start is called before the first frame update
    public float blockDuration;
    private float maxBlockDuration;
    public float blockInterval = 10f;
    public float blockAngleInDegrees = 50f;
    public Transform rotatePoint;
    public GameObject arms;
    [SerializeField] private float timer;
    private bool isBlocking = false;
    private float blockAngleRatioDuration;
    private float undoBlockDuration;
    public float unblockRate = 1.5f;

    void Start()
    {
        maxBlockDuration = blockDuration;
        undoBlockDuration = 0;
        blockDuration = 0;
        blockAngleRatioDuration = blockAngleInDegrees / maxBlockDuration;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (blockDuration > 0)
        {
            // Moves arms up to block
            blockDuration -= Time.deltaTime;
            arms.transform.RotateAround(rotatePoint.position, Vector3.forward, -(blockAngleRatioDuration*Time.deltaTime));
        }
        else if (blockDuration < 0)
        {
            // Starts undo animation
            undoBlockDuration = maxBlockDuration;
            isBlocking = false;
            blockDuration = 0;
            timer = 0;
        }
        else if (blockDuration == 0 && undoBlockDuration > 0) {
            // Moves arms back down after blocking
            undoBlockDuration -= unblockRate*Time.deltaTime;
            arms.transform.RotateAround(rotatePoint.position, Vector3.forward, unblockRate*blockAngleRatioDuration*Time.deltaTime);
        }

        if (!isBlocking && timer > blockInterval)
        {
            blockDuration = maxBlockDuration;
            isBlocking = true;
        }

    }
}
