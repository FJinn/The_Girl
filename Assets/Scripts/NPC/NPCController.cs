using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    // control update to happen only once
    [SerializeField] bool changedToAlly = false;
    // control change this game object into ally 
    [SerializeField] bool isAlly = false;

    [SerializeField] string myName;
    [SerializeField] ElementType myStrength;
    [SerializeField] ElementType myWeakness;
    [SerializeField] float myBaseDamage;
    [SerializeField] float myBaseDefense;
    BattleNPC me;

    private void Update()
    {
        if(!changedToAlly && isAlly)
        {
            changedToAlly = true;
            me = new BattleNPC(myBaseDamage, myBaseDefense, myStrength, myWeakness, true);
            me.SetName(myName);
        }
    }
}
