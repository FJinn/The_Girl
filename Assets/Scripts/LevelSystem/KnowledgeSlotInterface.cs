using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KnowledgeSlotInterface : MonoBehaviour
{
    static List<KnowledgeSlotController> myKnowledgeSlotList;

    public static void AddToList(KnowledgeSlotController mySlot)
    {
        myKnowledgeSlotList.Add(mySlot);
    }
}
