using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCTypes
{
    NPC,
    ALLY,
    MONSTER
};

[System.Serializable]
public class BattleNPC
{
    [SerializeField] string myName;
    [SerializeField] ElementType myStrength;
    [SerializeField] ElementType myWeakness;
    [SerializeField] protected NPCTypes myType;
    [SerializeField] float myBaseDamage;
    [SerializeField] float myBaseDefense;
    
    float myDamage;
    float myDefense;

    float totalDamageReceived;

    bool isDefend = false;

    // constructor
    public BattleNPC(float baseDmg, float baseDef, ElementType strength, ElementType weakness, bool _isAlly)
    {
        myBaseDamage = baseDmg;
        myBaseDefense = baseDef;
        myStrength = strength;
        myWeakness = weakness;

        if(_isAlly)
        {
            myType = NPCTypes.ALLY;
            GirlController.Instance.AddAlly(this);
        }
    }

    public void SetName(string name)
    {
        myName = name;
    }

    public string GetName()
    {
        return myName;
    }

    public ElementType GetStrength()
    {
        return myStrength;
    }

    public ElementType GetWeakness()
    {
        return myWeakness;
    }

    public void SetNPCType(NPCTypes type)
    {
        myType = type;
    }

    public NPCTypes GetNPCType()
    {
        return myType;
    }

    public float GetBaseDamage()
    {
        return myBaseDamage;
    }

    public float GetBaseDefense()
    {
        return myBaseDefense;
    }

    public void SetDamage(float value)
    {
        myDamage = value;
    }

    public float GetDamage()
    {
        return myDamage;
    }

    public void SetDefense(float value)
    {
        myDefense = value;
    }

    public float GetDefense()
    {
        return myDefense;
    }

    public bool GetDefendBool()
    {
        return isDefend;
    }

    public void SetDefendBool(bool bo)
    {
        isDefend = bo;
    }
}

public class Monster : BattleNPC
{
    float myHP;
    [SerializeField] List<Knowledge> myKnowledgeSkillList;
    public Monster(float baseDmg, float baseDef,ElementType strength,ElementType weakness) :base ( baseDmg,  baseDef, strength, weakness, false)
    {
        myType = NPCTypes.MONSTER;
    }

    public float GetMyHP()
    {
        return myHP;
    }

    public void SetMyHP(float value)
    {
        myHP = value;
    }

    public List<Knowledge> GetMyKnowledgeList()
    {
        return myKnowledgeSkillList;
    }

    public void SetMyKnowledge(Knowledge newKnowledge)
    {
        myKnowledgeSkillList.Add(newKnowledge);
    }

    void ChooseAction()
    {

    }
}

//public class Ally : BattleNPC
//{
//    float baseDamage;
//    float baseDefense;

//    // constructor
//    public Ally(float dmg, float def) : base(dmg, def) {}
    
//}
