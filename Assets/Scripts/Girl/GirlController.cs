using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour
{
    private static GirlController instance;
    public static GirlController Instance { get { return instance; } }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    
    enum EmotionType
    {
        HAPPY,
        SAD,
        ANGRY,
        SCARE,
        NEUTRAL
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

    //Ally
    [SerializeField] static List<BattleNPC> allyList;

    public List<BattleNPC> GetAllyList()
    {
        return allyList;
    }

}
