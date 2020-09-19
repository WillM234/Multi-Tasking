using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class UIButtonControl : MonoBehaviour
{
    #region Buttons
    public Button Options, FastForward, Normal, Pause;
    public int TimeScaleSpeed, lastTimeSpeed;
    public bool OneTime,TimeSet, OptionsClicked,FastForwardClicked,NormalClicked, PauseClicked;
    public bool isPause;
    #endregion
    #region Referenced Scripts
    public PlayerActions Player_A;
    #endregion
    private void Awake()
    {
        PauseClicked = true;
    }
    void Update()
    {
        ///What happens when a key/button  is pressed as long as Player's GameState is Active///
        if (Player_A.currentState == PlayerActions.GameState.Active)
        {
            if (Input.GetKeyDown(KeyCode.M) || FastForwardClicked)
            {
                TimeScaleSpeed = 2;
                FastForwardClicked = true;
                NormalClicked = false;
                PauseClicked = false;
                FastForward.interactable = false;
                Normal.interactable = true;
                Pause.interactable = true;
                TimeSet = false;
                if (TimeSet == false)
                {
                    SetLastTimeSpeed();
                }
            }//Fast Forward interactions
            if (Input.GetKeyDown(KeyCode.N) || NormalClicked)
            {
                TimeScaleSpeed = 1;
                FastForwardClicked = false;
                NormalClicked = true;
                PauseClicked = false;
                Normal.interactable = false;
                FastForward.interactable = true;
                Pause.interactable = true;
                TimeSet = false;
                if(TimeSet == false)
                {
                    SetLastTimeSpeed();
                }  
            }//Normal interactions
            if (Input.GetKeyDown(KeyCode.Space)||PauseClicked)
            {
                TimeScaleSpeed = 0;
                PauseClicked = true;
                NormalClicked = false;
                FastForwardClicked = false;
                Pause.interactable = false;
                Normal.interactable = true;
                FastForward.interactable = true;
            }//Pause interactions
        }
    }
        ///What happens when a key/button is pressed as long as Player's GameState is Paused///
    public void OnOptionsClick()//What happens when the Options Button is clicked
    {
        OptionsClicked = true;
    }
    public void OnFastClick()//What happens when the Fast Forward Button is clicked
    {
        FastForwardClicked = true;
    }
    public void OnNormalClick()//What happen when the Normal Button is clicked
    {
        NormalClicked = true;
    }
    public void OnPauseClick()
    {
        PauseClicked = true;
        isPause = true;
    }
    public void SetLastTimeSpeed()
    {
        lastTimeSpeed = TimeScaleSpeed;
        TimeSet = true;
    }
}
