using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Depth : MonoBehaviour
{   
    [Header("Component")]
    public TextMeshProUGUI depthText;

    [Header("Depth Settings")]
    public float currentDepth;
    public bool countDown;
    public float countSpeed;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float depthLimit;

    void Start()
    {

    }

    void Update()
    {
        currentDepth = countDown ? currentDepth -= countSpeed : currentDepth += countSpeed;

        if (hasLimit && ((countDown && currentDepth <= depthLimit) || (!countDown && currentDepth >= depthLimit)))
        {
            currentDepth = depthLimit;
            SetDepthText();
            enabled = false;
        }

        SetDepthText();
    }

    private void SetDepthText()
    {
        depthText.text = currentDepth.ToString("0");
    }
}