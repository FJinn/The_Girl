using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for debug
using UnityEngine.UI;

[System.Serializable]
public class KnowledgeSlotInterface : MonoBehaviour
{
    [SerializeField] List<KnowledgeSlotController> myKnowledgeSlotList;

    // index for knowledge slot
    int knowledgeSlotIndex;

    public void AddToList(int id, KnowledgeSlotController mySlot)
    {
        myKnowledgeSlotList.Insert(id, mySlot);
    }

    private void Update()
    {
        if(GameStateManager.Instance.GetGameState() == GameState.KNOWLEDGE_PANEL)
        {
            SelectKnowledgeSlot();
        }
    }

    void SelectKnowledgeSlot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (knowledgeSlotIndex < myKnowledgeSlotList.Count - 1)
            {
                myKnowledgeSlotList[knowledgeSlotIndex].SlotIsNotSelected();
                knowledgeSlotIndex += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (knowledgeSlotIndex > 0)
            {
                myKnowledgeSlotList[knowledgeSlotIndex].SlotIsNotSelected();
                knowledgeSlotIndex -= 1;
            }
        }

        if (!myKnowledgeSlotList[knowledgeSlotIndex].Activated())
        {
            myKnowledgeSlotList[knowledgeSlotIndex].SlotIsSelected();
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
    // sprite to display for this knowledge
    [SerializeField] Sprite mySprite;

    // default constructor
    public Knowledge() { }

    // overload constructor
    public Knowledge(int ID, string name, string description, ElementType element, KnowledgeType type, float value, Sprite sprite)
    {
        myID = ID;
        myName = name;
        myDescription = description;
        myElement = element;
        myType = type;
        myValue = value;
        mySprite = sprite;
    }

    public int GetID()
    {
        return myID;
    }

    public Sprite GetSprite()
    {
        return mySprite;
    }

    public float GetValue()
    {
        return myValue;
    }
}
