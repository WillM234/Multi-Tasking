using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VerbTimer : MonoBehaviour
{
    #region Timer Stuff
    public float timeLeft;
    private float startTime;
    public Text countDown;
    #endregion
    #region GameState Stuff
    private PlayerActions Player_A;
    public enum GameState {Active,Paused,Deactivated}
    public GameState currentState;
    #endregion
    private void Awake()
    {
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        currentState = GameState.Active;
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
            currentState = GameState.Paused;
            }
    if(Player_A.currentState == PlayerActions.GameState.Active)
        {
            currentState = GameState.Active;
        }
    ///other stuff being updated constantly///
        countDown.text = ("" + timeLeft);
        if(timeLeft < 0)
        {
            currentState = GameState.Deactivated;
        }
    }
    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if(currentState == GameState.Active)
            {
                timeLeft -= 1;
            }
            if(currentState == GameState.Paused)
            {
                timeLeft -= 0;
            }
        }
    }
    public void Reactivate()
    {
        timeLeft = startTime;
        currentState = GameState.Active;
    }
}