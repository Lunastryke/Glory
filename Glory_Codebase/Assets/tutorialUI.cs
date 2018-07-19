﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialUI : MonoBehaviour
{

    // References
    public StateSystem stateSystem;

    public GameObject TutorialCanvas;
    public GameObject IntroScene;
    public GameObject WalkScene;
    public GameObject JumpScene;
    public GameObject AttackScene;
    public GameObject DashScene;
    public GameObject DoneScene;

    void Awake()
    {
        TutorialCanvas.SetActive(true);
        IntroScene.SetActive(true);
        stateSystem.SetTutorialState(StateSystem.TutorialState.Dash);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            prevState();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            nextState();
        }
    }

    public void nextState()
    {
        if (stateSystem.IsIntro())
        {
            WalkScene.SetActive(true);
            IntroScene.SetActive(false);
            stateSystem.SetTutorialState(StateSystem.TutorialState.Walk);
        }

        else if (stateSystem.IsWalk())
        {
            JumpScene.SetActive(true);
            WalkScene.SetActive(false);
            stateSystem.SetTutorialState(StateSystem.TutorialState.Jump);
        }

        else if (stateSystem.IsJump())
        {
            JumpScene.SetActive(false);
            AttackScene.SetActive(true);
            stateSystem.SetTutorialState(StateSystem.TutorialState.Attack);
        }

        else if (stateSystem.IsAttack())
        {
            AttackScene.SetActive(false);
            DashScene.SetActive(true);
            stateSystem.SetTutorialState(StateSystem.TutorialState.Dash);
        }

        else if (stateSystem.IsDash())
        {
            DashScene.SetActive(false);
            DoneScene.SetActive(true);
            stateSystem.SetTutorialState(StateSystem.TutorialState.Done);
        }

        else if (stateSystem.IsDone())
        {
            DoneScene.SetActive(false);

        }
    }

    public void prevState()
    {
        if (!stateSystem.IsIntro())
        {
            if (stateSystem.IsWalk())
            {
                WalkScene.SetActive(false);
                IntroScene.SetActive(true);
                stateSystem.SetTutorialState(StateSystem.TutorialState.Intro);
            }

            else if (stateSystem.IsJump())
            {
                JumpScene.SetActive(false);
                WalkScene.SetActive(true);
                stateSystem.SetTutorialState(StateSystem.TutorialState.Walk);
            }

            else if (stateSystem.IsAttack())
            {
                AttackScene.SetActive(false);
                JumpScene.SetActive(true);
                stateSystem.SetTutorialState(StateSystem.TutorialState.Jump);
            }

            else if (stateSystem.IsDash())
            {
                DashScene.SetActive(false);
                AttackScene.SetActive(true);
                stateSystem.SetTutorialState(StateSystem.TutorialState.Attack);
            }
            else if (stateSystem.IsDone())
            {
                DoneScene.SetActive(false);
                DashScene.SetActive(true);
                stateSystem.SetTutorialState(StateSystem.TutorialState.Dash);
            }
        }
    }
}
