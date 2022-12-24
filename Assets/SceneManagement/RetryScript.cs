using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;
    }
    
    public void RetryGame()
    {
        if (timer > 2)
        {
            SceneManager.LoadScene(1);
        }
    }
}

