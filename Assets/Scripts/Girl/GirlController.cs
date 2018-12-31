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
    [SerializeField] float myCurrentHP;
    [SerializeField] float myHPLimit;
    /// <summary>
    /// EQ level that affects damage, defend, and heal
    /// </summary>
    [SerializeField] float myEq;
    [SerializeField] int myKnowledgePoint;

    // my emotion status
    /// <summary>
    /// emotion level determines controllable or uncontrollable action
    /// </summary>
    [SerializeField] float myEmotionLevel;
    [SerializeField] float myEmotionLevelRate;
    [SerializeField] EmotionType myEmotionType;

    // my current skill
    public static List<Knowledge> skillList;

    // my current item
    public static List<Item> itemList;

    //Ally
    public static List<BattleNPC> allyList;

    // my battle selection controller
    BattleSelectionController myBattleSelectionController;
    // my battle phase controller
    BattlePhaseController myBattlePhaseController;

    // ------------------------------------------------------------------------- //
    // ------------------------------------------------------------------------- //
    // ------------------------------------------------------------------------- //
    // ----------------------------- Set & Get ZONE ---------------------------- //
    // ------------------------------------------------------------------------- //
    // ------------------------------------------------------------------------- //
    // ------------------------------------------------------------------------- //

    public void SetCurrentHP(float value)
    {
        myCurrentHP = value;
    }

    public float GetCurrentHP()
    {
        return myCurrentHP;
    }

    public void SetHPLimit(float value)
    {
        myHPLimit = value;
    }

    public float GetHPLimit()
    {
        return myHPLimit;
    }

    public void SetEQ(float value)
    {
        myEq = value;
    }

    public float GetEQ()
    {
        return myEq;
    }

    public void SetKnowledgePoint(int value)
    {
        myKnowledgePoint = value;
    }

    public int GetKnowledgePoint()
    {
        return myKnowledgePoint;
    }

    public void SetBattleSelectionController(BattleSelectionController bc)
    {
        myBattleSelectionController = bc;
    }

    public BattleSelectionController GetBattleSelectionController()
    {
        return myBattleSelectionController;
    }

    public void SetBattlePhaseController(BattlePhaseController bp)
    {
        myBattlePhaseController = bp;
    }

    public BattlePhaseController GetBattlePhaseController()
    {
        return myBattlePhaseController;
    }

    public void SetEmotionLevel(float value)
    {
        myEmotionLevel = value * myEmotionLevelRate;
    }

    public float GetEmotionLevel()
    {
        return myEmotionLevel;
    }

    public void SetEmotionLevelRate(float value)
    {
        myEmotionLevelRate = value;
    }

    public float GetEmotionLevelRate()
    {
        return myEmotionLevelRate;
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

