using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{

    void Awake() {
        PlayerPrefs.DeleteAll();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }        
    }
}
