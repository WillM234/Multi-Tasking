using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardTimer : MonoBehaviour
{
    #region Timer
    public float timeLeft, currentTime;
    public Text countDown;
    public bool setTimer;
    private UIButtonControl ButtonControl;
    #endregion
    #region CardState
    public enum GameState {ActiveState, PauseState, DeactiveState};
    public GameState currentState;
    private PlayerActions Player_A;
    #endregion
    [Header("Input Card Asset Here")]
    public CardAsset cardAsset;
    private void Awake()
    {
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        ButtonControl = GameObject.Find("MainCamera").GetComponent<UIButtonControl>();
        currentState = GameState.ActiveState;
    }
    void Start()
    {
        if (cardAsset.Aspect_Job == true)
        {
                StartCoroutine("LoseTimer");
                Time.timeScale = 1;
        }
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
        ///other stuff being updated constantly///
        if (cardAsset.Aspect_Job == true)
        {
            countDown.text = ("" + timeLeft);
        }
        else
            countDown.text = "";
        if(timeLeft <= 0)
        {
            currentState = GameState.DeactiveState;
        }
        if(currentState == GameState.DeactiveState)
        {

        }
    }
    IEnumerator LoseTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (cardAsset.Aspect_Job == true)
            {
                if (currentState == GameState.ActiveState)
                {
                    if (ButtonControl.FastForwardClicked == true)
                    {
                        timeLeft -= 2;
                    }
                    if (ButtonControl.NormalClicked == true)
                    {
                        timeLeft -= 1;
                    }
                    if (ButtonControl.PauseClicked == true)
                    {
                        timeLeft -= 0;
                    }
                }
                if (currentState == GameState.PauseState)
                {
                    timeLeft -= 0;
                }
            }
        }
    }
}
