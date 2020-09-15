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
    #endregion
    #region GameStates
    public enum GameState {ActiveState, PauseState, resetState}
    public GameState currentState;
    public bool hasReset;
    #endregion
    private void Awake()
    {
        currentState = GameState.ActiveState;
        startTime = timeLeft;
    }
    void Start()
    {
        if(currentState == GameState.ActiveState)
        {
            StartCoroutine("LoseTime");
            Time.timeScale = 1;
        }
    }
    void Update()
    {
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
            if(currentState == GameState.ActiveState)
            {
                timeLeft -= 1;
            }
            if(currentState == GameState.PauseState)
            {
                timeLeft -= 0;
            }
        }
    }
}