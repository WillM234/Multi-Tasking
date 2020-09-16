using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerActions : MonoBehaviour
{
    #region Movement Control Stuff
    public float X_Max, X_Min, Y_Max, Y_Min;
    public Vector3 PlayerPos;
    #endregion
    #region Game States
    public enum GameState {Active, Paused}
    public GameState currentState;
    #endregion
    #region UI Stuff
    private GameObject PausePanel;
    #endregion
    private void Awake()
    {
        currentState = GameState.Active;
        PausePanel = GameObject.Find("FullyPausePanel");
    }
    void Start()
    {

    }
    void Update()
    {
 PlayerPos = transform.position;//sets players current position
 ////player movement inputs if game is not fully paused////
 if(currentState == GameState.Active)
        {
            PausePanel.SetActive(false);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-1f, 0f, 0f);
            }//player moves left
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(1f, 0f, 0f);
            }//player moves right
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0f, 1f, 0f);
            }//player moves up
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0f, -1f, 0f);
            }//player moves down
        }//stuff that happens when game state is active
 if(Input.GetKeyDown(KeyCode.Escape))
        {
            currentState = GameState.Paused;
        }
 /////player position limits////
 if(PlayerPos.x > X_Max)
        {
            PlayerPos.x = X_Max;
        }//max amount the player can move right in the x-direction
 if(PlayerPos.x < X_Min)
        {
            PlayerPos.x = X_Min;
        }//max amount the player can move left in the x-direction
 if(PlayerPos.y > Y_Max)
        {
            PlayerPos.y = Y_Max;
        }//max amount the player can move up in the y-direction
 if(PlayerPos.y < Y_Min)
        {
            PlayerPos.y = Y_Min;
        }//max amount the player can move down in the y-direction
 ////Stuff that happens when the game is fully paused/////
 if(currentState == GameState.Paused)
        {
            PausePanel.SetActive(true);
        }
    }
public void UnPause()
    {
        currentState = GameState.Active;
        PausePanel.SetActive(false);
    }
}