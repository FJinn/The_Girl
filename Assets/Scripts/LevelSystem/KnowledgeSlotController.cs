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
    [SerializeField] bool isActivated;

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
    public void ActivateSlot()
    {
        // activated
        isActivated = true;
        // set next slot active
        ActivateNextSlot();
        // update girl knowledge point
        ReduceKnowledgePoint();
        // add this slot knowledge to girl skill list
        UpdateGirlKnowledge();
    }

    // Reduce Girl knowledge point by myCost
    void ReduceKnowledgePoint()
    {
        int tempKP = GirlController.Instance.GetKnowledgePoint();
        tempKP -= myCost;
        GirlController.Instance.SetKnowledgePoint(tempKP);
    }

    // Add this knowledge to girl
    void UpdateGirlKnowledge()
    {
        if (myType == KnowledgeType.SKILL)
        {
            GirlController.skillList.Add(myKnowledge);
        }
        else if(myType == KnowledgeType.EMOTION_RATE)
        {
            float tempRate = GirlController.Instance.GetEmotionLevelRate();
            tempRate += myValue;
            GirlController.Instance.SetEmotionLevelRate(tempRate);
        }
        else if(myType == KnowledgeType.ATTRIBUTE_HP)
        {
            float tempHP = GirlController.Instance.GetHPLimit();
            tempHP += myValue;
            GirlController.Instance.SetHPLimit(tempHP);
        }
        else if (myType == KnowledgeType.ATTRIBUTE_EQ)
        {
            float tempEQ = GirlController.Instance.GetEQ();
            tempEQ += myValue;
            GirlController.Instance.SetEQ(tempEQ);
        }
    }

    // Activate next slot after this slot is on
    void ActivateNextSlot()
    {
        for(int i=0; i<nextSlot.Length; i++)
        {
            nextSlot[i].enabled = true;
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


