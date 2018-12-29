using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCTypes
{
    ALLY,
    MONSTER
};

public class BattleNPC : MonoBehaviour
{
    [SerializeField] ElementType myStrength;
    [SerializeField] ElementType myWeakness;
    [SerializeField] protected NPCTypes myType;
    [SerializeField] float myBaseDamage;
    [SerializeField] float myBaseDefense;
    float myHP;

    float myDamage;
    float myDefense;

    float totalDamageReceived;

    // constructor
    public BattleNPC(float baseDmg, float baseDef, ElementType strength, ElementType weakness)
    {
        baseDmg = myBaseDamage;
        baseDef = myBaseDefense;
    }

    public ElementType GetStrength()
    {
        return myStrength;
    }

    public ElementType GetWeakness()
    {
        return myWeakness;
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

    public float GetMyHP()
    {
        return myHP;
    }

    public void SetMyHP(float value)
    {
        value = myHP;
    }
}

public class Monster : BattleNPC
{
    
    [SerializeField] List<Knowledge> myKnowledgeSkillList;
    public Monster(float baseDmg, float baseDef,ElementType strength,ElementType weakness) :base ( baseDmg,  baseDef, strength, weakness)
    {
        myType = NPCTypes.MONSTER;
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
