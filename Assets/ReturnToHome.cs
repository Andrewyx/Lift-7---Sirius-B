using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHome : MonoBehaviour
{
    public void SendToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
