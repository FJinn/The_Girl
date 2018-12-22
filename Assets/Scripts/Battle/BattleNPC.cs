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
    [SerializeField] NPCTypes myType;
    [SerializeField] float myBaseDamage;
    [SerializeField] float myBaseDefense;

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

//public class Ally : BattleNPC
//{
//    float baseDamage;
//    float baseDefense;

//    // constructor
//    public Ally(float dmg, float def) : base(dmg, def) {}
    
//}
