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
    #endregion
    #region CardState
    public enum GameState {ActiveState, PauseState, DeactiveState};
    public GameState currentState;
    #endregion
    [Header("Input Card Asset Here")]
    public CardAsset cardAsset;
    private void Awake()
    {
        currentState = GameState.ActiveState;
    }
    void Start()
    {
        if (cardAsset.Aspect_Job == true)
        {
            if(currentState == GameState.ActiveState)
            {
                StartCoroutine("LoseTimer");
                Time.timeScale = 1;
            }
        }
    }
    void Update()
    {
        countDown.text = ("" + timeLeft);
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
            if(currentState == GameState.ActiveState)
            {
                timeLeft -= 1;
            }
            if (currentState == GameState.PauseState)
            {
                timeLeft -= 0;
            }  
        }
    }
}
