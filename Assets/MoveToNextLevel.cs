using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public int nextSceneLoad;
    //public GameObject myDepth;
    //public float numberOfLevels;
    //private Depth depthScript;
    //private float ascentPerlevel;
    //private float ascentSoFar;
     
    void Awake()
    {
        //depthScript = myDepth.GetComponent<Depth>();
    }

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void NextLevel() 
    {
        /*ascentPerlevel = (5844f - depthScript.currentDepth) - ascentSoFar;
        if(ascentPerlevel == 5844f / numberOfLevels)
        {
            ascentSoFar += ascentSoFar; */
            SceneManager.LoadScene(nextSceneLoad);

            if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        //}
    } 

}
