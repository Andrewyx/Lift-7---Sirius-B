using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    private int levelAt;


    void Awake()
    {
        levelAt = PlayerPrefs.GetInt("levelAt", 1);
    }
    void Start()
    {       
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }
}