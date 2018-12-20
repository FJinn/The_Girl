using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour
{
    enum EmotionType
    {
        Happy,
        Sad,
        Angry,
        Scare,
        Neutral
    }

    // my attributes
    [SerializeField] float myHP;
    [SerializeField] float myEQ;
    [SerializeField] int myKnowledgePoint;

    // my emotion status
    [SerializeField] float myEmotionLevel;
    [SerializeField] EmotionType myEmotion;

    // my current skill
    [SerializeField] static List<Skill> skillList;

    // my current item
    [SerializeField] static List<Item> itemList;

    // in battle variable
    // Ally
    [SerializeField] Ally selectedAlly;

    // Action
    Action myAction;


}
