using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KnowledgeSlotController : MonoBehaviour
{
    // cache knowledge information
    [SerializeField] string myName;
    [SerializeField] string myDescription;
    [SerializeField] ElementType myElement;
    [SerializeField] KnowledgeType myType;
    [SerializeField] float myValue;

    // create a knowledge for this slot
    Knowledge myKnowledge;

    // cache next slot(s)
    [SerializeField] KnowledgeSlotController[] nextSlot;

    // slot status that control activation
    bool isActivated;

    // cost of slot activation
    int myCost;

    private void Awake()
    {
        // initialize the slot content
        myKnowledge = new Knowledge(myName, myDescription, myElement, myType, myValue);
        // add to knowledgeSlotInterface list
        KnowledgeSlotInterface.AddToList(this);
    }

    // spent knowledge point and turn this slot on
    void ChangeStatus()
    {

    }

    // reduce Girl knowledge point by myCost
    void ReduceKnowledgePoint()
    {

    }

    // Activate next slot after this slot is on
    void ActivateNextSlot()
    {

    }
}

public enum KnowledgeType
{
    SKILL,
    ATTRIBUTE,
    BUFF,
    BLANK
}

public enum ElementType
{
    FIRE,
    WATER,
    PLANT,
    BLANK
}

public class Knowledge
{
    string myName;
    string myDescription;
    ElementType myElement;
    KnowledgeType myType;
    // value that adjust Girl attribute, skill, or buff
    float myValue;

    // default constructor
    public Knowledge() { }

    // overload constructor
    public Knowledge(string name, string description, ElementType element, KnowledgeType type, float value) { }

}


