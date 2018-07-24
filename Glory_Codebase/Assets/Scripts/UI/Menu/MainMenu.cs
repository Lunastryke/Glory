﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public StateSystem stateSystem;
    public GameObject mainMenu;
    public Overlay overlay;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().PlaySound("MenuBGM");
        Debug.Log("PlayMenuBGM");
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        stateSystem.EnterGame();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
