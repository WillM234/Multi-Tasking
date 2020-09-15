using UnityEditor;
using UnityEngine;

public class CardIntegration
{
   [MenuItem("Assets/Create/CardAsset")]
   public static void CreateYourScriptableObject()
    {
        SOUnity.CreateAsset<CardAsset>();
    }
}
