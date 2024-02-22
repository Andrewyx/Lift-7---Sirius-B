using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void NextLevel() 
    {
        if(SceneManager.GetActiveScene().buildIndex <= 4)
        {
            SceneManager.LoadScene(nextSceneLoad);
            PlayerPrefs.SetInt("levelAt", nextSceneLoad-1);
        }

        
    } 

}
