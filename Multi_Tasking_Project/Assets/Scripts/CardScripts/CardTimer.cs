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
    private CardPositioning VerbW, VerbE, VerbS, TPasses;
    public Vector3 CardPos;
    public bool in_wSnap,in_tSnap,in_eSnap,in_sSnap;
    private void Awake()
    {
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
        ButtonControl = GameObject.Find("MainCamera").GetComponent<UIButtonControl>();
        VerbW = GameObject.Find("Verb_Work").GetComponent<CardPositioning>();
        VerbE = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbS = GameObject.Find("Verb_Study").GetComponent<CardPositioning>();
        TPasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
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
        //tracking card Position
        CardPos = transform.position;
        ///Switching States when game is fully paused or not fully paused///
        if(Player_A.currentState == PlayerActions.GameState.Paused)
        {
            currentState = GameState.PauseState;
        }
        if(Player_A.currentState == PlayerActions.GameState.Active)
        {
            if (CardPos != VerbW.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Job == true))
                in_wSnap = false;
            if (CardPos != VerbS.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Manuscript == true))
                in_sSnap = false;
            if (CardPos != VerbE.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Place == true))
                in_eSnap = false;
            if (CardPos != TPasses.SnapPosition)
                in_tSnap = false;
            if (CardPos == VerbW.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Job == true))
                {in_wSnap = true;
                 in_sSnap = false;
                 in_eSnap = false;
                 in_tSnap = false;}
            if (CardPos == VerbS.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Manuscript == true))
                {in_wSnap = false;
                 in_sSnap = true;
                 in_eSnap = false;
                 in_tSnap = false;}
            if (CardPos == VerbE.SnapPosition && (cardAsset.Aspect_Skill == true || cardAsset.Aspect_Place == true))
                {in_wSnap = false;
                 in_sSnap = false;
                 in_eSnap = true;
                 in_tSnap = false;}
            if(CardPos == TPasses.SnapPosition)
                {in_wSnap = false;
                 in_sSnap = false;
                 in_eSnap = false;
                 in_tSnap = true;}
            if (in_wSnap || in_sSnap|| in_eSnap||in_tSnap)
                    currentState = GameState.PauseState;
                else if (!in_wSnap && !in_sSnap && !in_eSnap && !in_tSnap)
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
