using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectScene : MonoBehaviour
{
    public int sceneToSwitchTo;
    public void SelectScene()
    {
         SceneManager.LoadScene(sceneToSwitchTo);
    }
}
