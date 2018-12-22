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
    [SerializeField] public ElementType myStrength;
    [SerializeField] public ElementType myWeakness;
    [SerializeField] public NPCTypes myType;
    [SerializeField] public float myBaseDamage;
    [SerializeField] public float myBaseDefense;

    float myDamage;
    string myDefense;

    float totalDamageReceived;

    // constructor
    public BattleNPC(float baseDmg, float baseDef)
    {
        baseDmg = myBaseDamage;
        baseDef = myBaseDefense;
    }

    private void Awake()
    {

    }

    void CalculateDamageReceived()
    {

    }
}
public class Monster : BattleNPC
{
    [SerializeField] float myHP;
    [SerializeField] Knowledge myKnowledgeSkill;
    public Monster(float baseDmg, float baseDef,float myhp,ElementType myStrh,ElementType myWea,Knowledge myKnowledge) :base ( baseDmg,  baseDef)
    {     
        myhp = myHP;
        myStrh = myStrength;
        myWea = myWeakness;
        myKnowledge = myKnowledgeSkill;
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
