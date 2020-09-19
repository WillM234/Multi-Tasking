using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerActions : MonoBehaviour
{
    #region Movement Control Stuff
    public float X_Max, X_Min, Y_Max, Y_Min,xPos,yPos,zPos;
    public Vector3 PlayerPos;
    #endregion
    #region Game States
    public enum GameState {Active, Paused}
    public GameState currentState;
    #endregion
    #region UI Stuff
    private GameObject PausePanel;
    public UIButtonControl ButtonControl;
    #endregion
    private void Awake()
    {
        currentState = GameState.Active;
        PausePanel = GameObject.Find("FullyPausePanel");
    }
    void Update()
    {
PlayerPos = transform.position;//sets players current position
xPos = transform.position.x;
yPos = transform.position.y;
zPos = transform.position.z;
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
 /////player position limits////
 if(PlayerPos.x > X_Max)
        {
            transform.position = new Vector3(X_Max, yPos, zPos);
        }//max amount the player can move right in the x-direction
 if(PlayerPos.x < X_Min)
        {
            transform.position = new Vector3(X_Min, yPos, zPos);
        }//max amount the player can move left in the x-direction
 if(PlayerPos.y > Y_Max)
        {
            transform.position = new Vector3(xPos,Y_Max, zPos);
        }//max amount the player can move up in the y-direction
 if(PlayerPos.y < Y_Min)
        {
            transform.position = new Vector3(xPos,Y_Min,zPos);
        }//max amount the player can move down in the y-direction
 ///Other Stuff being tracked in update///
    if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Active)
            {
                Debug.Log("Game is now Paused");
                ButtonControl.OptionsClicked = true;
            }
            if(currentState == GameState.Paused)
            {
                Debug.Log("Game is now Active");
                UnPause();
            }
        }
    if(ButtonControl.OptionsClicked == true)
        {
            Pause();
        }
    }
public void UnPause()
    {
        currentState = GameState.Active;
        PausePanel.SetActive(false);
        ButtonControl.OptionsClicked = false;
        ButtonControl.Options.interactable = true;
    }
public void Pause()
    {
        currentState = GameState.Paused;
        PausePanel.SetActive(true);
        ButtonControl.OptionsClicked = true;
        ButtonControl.Options.interactable = false;
    }
}