using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb_Work : MonoBehaviour
{
    private CardPositioning VerbWork;
    private VerbTimer WorkTimer;
    public GameObject CurrencyPrefab;
    public Vector3 SpawnPoint;
    public int rewardAmount;
    public bool cardInPos,OneTime;
    private void Awake()
    {
        VerbWork = GetComponent<CardPositioning>();
        WorkTimer = GetComponent<VerbTimer>();
        SpawnPoint = new Vector3(VerbWork.SnapPosition.x, (VerbWork.SnapPosition.y - 100f), VerbWork.SnapPosition.z);
    }
    void Update()
    {
        foreach (GameObject card in VerbWork.Card)
        {

            if (card.GetComponent<CardTimer>().cardAsset.Aspect_Job == true)
            {
                if (card.transform.position == VerbWork.SnapPosition)
                {
                    cardInPos = true;
                    rewardAmount = card.GetComponent<CardTimer>().cardAsset.CurrencyReward;
                    if (WorkTimer.currentState == VerbTimer.GameState.Start)
                    {
                        WorkTimer.timeLeft = card.GetComponent<CardTimer>().cardAsset.JobTimer;
                        WorkTimer.startTime = WorkTimer.timeLeft;
                    }
                }
            }
        }
        if(WorkTimer.timeLeft > 0)
        {
            OneTime = false;
        }
        if(WorkTimer.timeLeft <= 0)
        {
            if (!OneTime)
            { SpawnReward(rewardAmount); }
        }
    }
    public void SpawnReward(int amount)
    {
        for (int i = 0; i < amount; i++)
            {
                Instantiate(CurrencyPrefab, SpawnPoint, Quaternion.identity);
            OneTime = true;
            }
    }
}
