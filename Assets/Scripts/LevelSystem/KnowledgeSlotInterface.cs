using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KnowledgeSlotInterface : MonoBehaviour
{
    static List<KnowledgeSlotController> myKnowledgeSlotList;

    public static void AddToList(int id, KnowledgeSlotController mySlot)
    {
        myKnowledgeSlotList.Insert(id, mySlot);
    }

    // index for knowledge slot
    int knowledgeSlotIndex;

    void SelectKnowledgeSlot()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (knowledgeSlotIndex > 0)
            {
                knowledgeSlotIndex -= 1;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (knowledgeSlotIndex < myKnowledgeSlotList.Count - 1)
            {
                knowledgeSlotIndex += 1;
            }
        }

        if (Input.GetKey(KeyCode.Z) && myKnowledgeSlotList[knowledgeSlotIndex].isActiveAndEnabled)
        {
            myKnowledgeSlotList[knowledgeSlotIndex].ActivateSlot();
        }
    }
}
