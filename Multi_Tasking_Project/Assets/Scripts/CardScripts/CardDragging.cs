using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragging : MonoBehaviour
{
    public bool UseP_Displacement = true;
    public bool dragging = false;
    Vector3 P_Displacement;
    public Vector3 CardPos;
    float Z_Displacement;

    [Header("Referenced Scripts")]
    private CardPositioning TimePasses,VerbWork,VerbExplore,VerbStudy;
    private PlayerActions Player_A;
    private void Awake()
    {
        ///reference scripts, grabbing them through code instead of through inspector///
        Player_A = GameObject.Find("MainCamera").GetComponent<PlayerActions>();
    }
    private void OnMouseDown()
    {
        dragging = true;
        Z_Displacement = -Camera.main.transform.position.z + transform.position.z;
        if (UseP_Displacement)
        { P_Displacement = -transform.position + MouseInWorldCoords(); }
        else
        { P_Displacement = Vector3.zero; }
    }
    private void OnMouseUp()
    {
        if (dragging)
        { dragging = false; }
    }
    private void Update()
    {
        CardPos = transform.position;
        if (dragging && Player_A.currentState == PlayerActions.GameState.Active && this.gameObject.tag == "Card")
        {
            Vector3 mousePos = MouseInWorldCoords();
            transform.position = new Vector3(mousePos.x - P_Displacement.x, mousePos.y - P_Displacement.y, transform.position.z);
        }
    }
    private Vector3 MouseInWorldCoords()
    {
        var screenMousePos = Input.mousePosition;
        screenMousePos.z = Z_Displacement;
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }
}
