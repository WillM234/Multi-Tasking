using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardAsset : ScriptableObject
{
    [Header("Card Aspects")]
    private CardAsset cardAsset;
    public bool Aspect_Job, Aspect_Currency, Aspect_Skill, Aspect_Place, Aspect_Manuscript, Aspect_Motivation;
    public CardAsset(CardAsset cardAsset)
    {
        this.cardAsset = cardAsset;
    }
}