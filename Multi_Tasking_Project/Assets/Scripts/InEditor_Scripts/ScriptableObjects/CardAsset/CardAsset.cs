using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardAsset : ScriptableObject
{
    [Header("Card Aspects")]
    private CardAsset cardAsset;
    public bool Aspect_Job, Aspect_Ingredient, Aspect_Skill, Aspect_Place, Aspect_Manuscript;

    [Header("For Aspect:Job Only")]
    public int CurrencyReward;
    public float JobTimer;
    public CardAsset(CardAsset cardAsset)
    {
        this.cardAsset = cardAsset;
    }
}