using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToLists : MonoBehaviour
{
    private CardPositioning TimePasses, VerbWork, VerbExplore, VerbStudy;
    private void Awake()
    {
        ///reference scripts, grabbing them through code instead of through inspector///
        TimePasses = GameObject.Find("TimePasses").GetComponent<CardPositioning>();
        VerbWork = GameObject.Find("Verb_Work").GetComponent<CardPositioning>();
        VerbExplore = GameObject.Find("Verb_Explore").GetComponent<CardPositioning>();
        VerbStudy = GameObject.Find("Verb_Study").GetComponent<CardPositioning>();
        ///Adding the card to the lists so they can be tracked///
        ///These Lists track all the cards
        TimePasses.Card.Add(gameObject);
        VerbWork.Card.Add(gameObject);
        VerbExplore.Card.Add(gameObject);
        VerbStudy.Card.Add(gameObject);
        //These Lists are for specific things
    }
}
