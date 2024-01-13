using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHome : MonoBehaviour
{
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;
    }
    
    public void SendToMenu()
    {
        if (timer > 4)
        {
        SceneManager.LoadScene(0);
        }
    }
}
