using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositioning : MonoBehaviour
{
    public List<GameObject> Card = new List<GameObject>();
    public float X_min, X_max, Y_min, Y_max;
    public Vector3 SnapPosition;
    private Vector3 CardPos;
    private void Update()
    {
        foreach(GameObject card in Card)
        {
            CardPos = card.transform.position;
            if((CardPos.x >= X_min && CardPos.x <= X_max)&&(CardPos.y <= Y_max && CardPos.y >= Y_min))
            {
                card.transform.position = SnapPosition;
            }
        }
    }
}
