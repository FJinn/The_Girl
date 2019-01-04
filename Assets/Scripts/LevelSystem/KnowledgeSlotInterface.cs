using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for debug
using UnityEngine.UI;

[System.Serializable]
public class KnowledgeSlotInterface : MonoBehaviour
{
    [SerializeField] List<KnowledgeSlotController> myKnowledgeSlotList;

    public void AddToList(int id, KnowledgeSlotController mySlot)
    {
        myKnowledgeSlotList.Insert(id, mySlot);
    }

    // index for knowledge slot
    int knowledgeSlotIndex;

    private void Update()
    {
        if(GameStateManager.Instance.GetGameState() == GameState.KNOWLEDGE_PANEL)
        {
            SelectKnowledgeSlot();
        }

        // debug
        if (!myKnowledgeSlotList[knowledgeSlotIndex].Activated())
        {
            myKnowledgeSlotList[knowledgeSlotIndex].gameObject.GetComponent<Image>().color = Color.yellow;
        }
    }

    void SelectKnowledgeSlot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (knowledgeSlotIndex < myKnowledgeSlotList.Count - 1)
            {
                knowledgeSlotIndex += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (knowledgeSlotIndex > 0)
            {
                knowledgeSlotIndex -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && !myKnowledgeSlotList[knowledgeSlotIndex].Activated())
        {
            myKnowledgeSlotList[knowledgeSlotIndex].ActivateSlot();
        }
    }
}

public enum KnowledgeType
{
    SKILL,
    ATTRIBUTE_HP,
    ATTRIBUTE_EQ,
    EMOTION_RATE,
    BLANK
}

public enum ElementType
{
    FIRE = 0,
    WATER,
    PLANT,
    BLANK
}

[System.Serializable]
public class Knowledge
{
    [SerializeField] int myID;
    [SerializeField] string myName;
    [SerializeField] string myDescription;
    [SerializeField] ElementType myElement;
    [SerializeField] KnowledgeType myType;
    // value that adjust Girl attribute, skill, or buff
    [SerializeField] float myValue;

    // default constructor
    public Knowledge() { }

    // overload constructor
    public Knowledge(int ID, string name, string description, ElementType element, KnowledgeType type, float value)
    {
        myID = ID;
        myName = name;
        myDescription = description;
        myElement = element;
        myType = type;
        myValue = value;
    }

    public int GetID()
    {
        return myID;
    }
}
