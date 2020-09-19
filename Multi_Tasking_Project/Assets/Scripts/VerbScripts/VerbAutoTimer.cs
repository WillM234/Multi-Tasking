using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VerbAutoTimer : MonoBehaviour
{
    #region Timer Stuff
    public float timeLeft;
    private float startTime;
    public Text countDown;
    public UIButtonControl ButtonControl;
    #endregion
    #region GameStates
    public enum GameState {ActiveState, PauseState, resetState}
    public GameState currentState;
    private PlayerActions Player_A;
    public bool hasReset;
    #endregion
    private void Awake()
    {
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        currentState = GameState.ActiveState;
        startTime = timeLeft;
    }
    void Start()
    {
            StartCoroutine("LoseTime");
            Time.timeScale = 1;
    }
    void Update()
    {
        ///Switching States when game is fully paused or not fully paused///
        if(Player_A.currentState == PlayerActions.GameState.Paused)
        {
            currentState = GameState.PauseState;
        }
        if(Player_A.currentState == PlayerActions.GameState.Active)
        {
            currentState = GameState.ActiveState;
        }
        ///other stuff being tracked constantly///
        countDown.text = ("" + timeLeft);
        if (timeLeft < 0)
        {
            currentState = GameState.resetState;
        }
        if (currentState == GameState.resetState)
        {
            timeLeft = startTime;
            hasReset = true;
        }
        if(hasReset)
        {
            currentState = GameState.ActiveState;
            hasReset = false;
        }
    }
    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (currentState == GameState.ActiveState)
            {
                if(ButtonControl.FastForwardClicked == true)
                {
                    timeLeft -= 2;
                }
                if(ButtonControl.NormalClicked == true)
                {
                    timeLeft -= 1;
                }
                if(ButtonControl.PauseClicked == true)
                {
                    timeLeft -= 0;
                }
            }
            if(currentState == GameState.PauseState)
            {
                timeLeft -= 0;
            }
        }
    }
}