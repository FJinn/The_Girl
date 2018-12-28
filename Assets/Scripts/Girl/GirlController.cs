using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GirlController : MonoBehaviour
{
    // const emotion level max
    public const float MAX_EMOTIONLEVEL = 100;

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
    
    // my attributes
    [SerializeField] float myHP;
    /// <summary>
    /// EQ level that affects damage, defend, and heal
    /// </summary>
    [SerializeField] float myEQ;
    [SerializeField] int myKnowledgePoint;

    // my emotion status
    /// <summary>
    /// emotion level determines controllable or uncontrollable action
    /// </summary>
    [SerializeField] float myEmotionLevel;
    [SerializeField] EmotionType myEmotionType;

    // my current skill
    public static List<Skill> skillList;

    // my current item
    public static List<Item> itemList;

    //Ally
    public static List<BattleNPC> allyList;

    // my battle controller
    BattleController myBattleController;

    // ------------------------------------------------------------------------- //
    // ------------------------------------------------------------------------- //
    // ------------------------------------------------------------------------- //
    // ----------------------------- Set & Get ZONE ---------------------------- //
    // ------------------------------------------------------------------------- //
    // ------------------------------------------------------------------------- //
    // ------------------------------------------------------------------------- //

    public void SetHP(float value)
    {
        myHP = value;
    }

    public float GetHP()
    {
        return myHP;
    }

    public void SetEQ(float value)
    {
        myEQ = value;
    }

    public float GetEQ()
    {
        return myEQ;
    }

    public void SetKnowledgePoint(int value)
    {
        myKnowledgePoint = value;
    }

    public int GetKnowledgePoint()
    {
        return myKnowledgePoint;
    }

    public void SetBattleController(BattleController bc)
    {
        myBattleController = bc;
    }

    public BattleController GetBattleController()
    {
        return myBattleController;
    }

    public void SetEmotionLevel(float value)
    {
        myEmotionLevel = value;
    }

    public float GetEmotionLevel()
    {
        return myEmotionLevel;
    }

    public void SetEmotionType(EmotionType et)
    {
        myEmotionType = et;
    }

    public EmotionType GetEmotionType()
    {
        return myEmotionType;
    }
}

public enum EmotionType
{
    HAPPY,
    SAD,
    ANGRY,
    SCARE,
    NEUTRAL
}

