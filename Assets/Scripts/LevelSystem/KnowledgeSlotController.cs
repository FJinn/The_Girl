using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for debug
using UnityEngine.UI;

[System.Serializable]
public class KnowledgeSlotController : MonoBehaviour
{
    // cache knowledge information
    [SerializeField] int myID;
    [SerializeField] string myName;
    [SerializeField] string myDescription;
    [SerializeField] ElementType myElement;
    [SerializeField] KnowledgeType myType;
    [SerializeField] float myValue;

    // create a knowledge for this slot
    Knowledge myKnowledge;

    // cache previous slot(s)
    [SerializeField] KnowledgeSlotController[] previousSlot;
    // cache next slot(s)
    [SerializeField] KnowledgeSlotController[] nextSlot;

    // slot status that control activation
    [SerializeField] bool isActivated;

    // cost of slot activation
    public int myCost;

    // cache girl controller
    GirlController girl;

    private void Awake()
    {
        // get girl controller
        girl = GirlController.Instance;
        // initialize the slot content
        myKnowledge = new Knowledge(myID, myName, myDescription, myElement, myType, myValue);
        // add to knowledgeSlotInterface list
        // assuming it will auto update when this script value is changed
        // for saving the data, telling data which has activated
        // awake initialize got problem, set to manual drag to list for now
        // girl.GetKnowledgeSlotInterface().AddToList(myID, this);
    }

    // for debug changing color
    private void Update()
    {
        if (!isActivated)
        {
            // change color to red for debug
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }

    // spent knowledge point and turn this slot on
    public void ActivateSlot()
    {
        if(previousSlot != null)
        {
            for (int i = 0; i < previousSlot.Length; i++)
            {
                if(previousSlot[i].isActivated)
                {
                    // break for loop and continue code below
                    break;
                }
                else if(i == previousSlot.Length - 1 && !previousSlot[i].isActivated)
                {
                    // return function and stop running code below
                    // debug
                    Debug.Log("Previous slot is not activated yet!");
                    return;
                }
            }
        }

        // check if knowledge point is enough to unlock
        int girlKP = girl.GetKnowledgePoint();
        if (girlKP >= myCost)
        {
            // change color to green for debug
            gameObject.GetComponent<Image>().color = Color.green;
            // activated
            isActivated = true;
            // set next slot active
            ActivateNextSlot();
            // update girl knowledge point
            ReduceKnowledgePoint();
            // add this slot knowledge to girl skill list
            UpdateGirlKnowledge();
        }
        else
        {
            // debug
            Debug.Log("Not enough knowledge point to unlock this knowledge!");
        }
    }

    // Reduce Girl knowledge point by myCost
    void ReduceKnowledgePoint()
    {
        int tempKP = girl.GetKnowledgePoint();
        tempKP -= myCost;
        girl.SetKnowledgePoint(tempKP);
    }

    // Add this knowledge to girl
    void UpdateGirlKnowledge()
    {
        if (myType == KnowledgeType.SKILL)
        {
            girl.AddSkill(myKnowledge);
        }
        else if(myType == KnowledgeType.EMOTION_RATE)
        {
            float tempRate = girl.GetEmotionLevelRate();
            tempRate += myValue;
            girl.SetEmotionLevelRate(tempRate);
        }
        else if(myType == KnowledgeType.ATTRIBUTE_HP)
        {
            float tempHP = girl.GetHPLimit();
            tempHP += myValue;
            girl.SetHPLimit(tempHP);
        }
        else if (myType == KnowledgeType.ATTRIBUTE_EQ)
        {
            float tempEQ = girl.GetEQ();
            tempEQ += myValue;
            girl.SetEQ(tempEQ);
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

    // get activation bool condition
    public bool Activated()
    {
        return isActivated;
    }
}


