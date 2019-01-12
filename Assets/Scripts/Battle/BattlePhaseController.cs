using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePhaseController : MonoBehaviour
{
    enum BattleState
    {
        ALLY,
        MONSTER,
        GIRL, // uncontrollable
        NONE
    }
    // current state
    BattleState myState;

    public static List<Monster> monsterList;
    [SerializeField] List<BattleNPC> girlAlly;
    [SerializeField] Action[] allyAction;
    GirlController girl;

    // cache defense num
    // should set max num for ally num somewhere
    float[] defense = new float[4];

    private void Awake()
    {
        girl = GirlController.Instance;
        girl.SetBattlePhaseController(this);
    }

    private void OnEnable()
    {
        girlAlly = BattleSelectionController.selectedAllyList;
        allyAction = BattleSelectionController.myAction;

        if(girlAlly != null)
        {
            // initialize defense array
            // get defense
            for (int j = 0; j < girlAlly.Count; j++)
            {
                if (girlAlly[j].GetDefendBool())
                {
                    defense[j] = girlAlly[j].GetBaseDefense() + girlAlly[j].GetDefense();
                }
                else
                {
                    // to ensure the value is not refered to Alien number
                    defense[j] = 0;
                }
            }
        }
    }

    private void Update()
    {
        if(myState == BattleState.ALLY)
        {
            AllyState();
        }
        else if(myState == BattleState.MONSTER)
        {
            MonsterState();
        }
        else if (myState == BattleState.GIRL)
        {
            GirlState();
        }
    }

    void AllyState()
    {
        for(int i=0; i<girlAlly.Count; i++)
        {
            allyAction[i].Behavior();
            Debug.Log(girlAlly[i].GetName() + " : " + allyAction[i]);
        }

        myState = BattleState.MONSTER;
    }

    void MonsterState()
    {
        for(int i=0; i<monsterList.Count; i++)
        {
            float hp = girl.GetCurrentHP();
            float damage = monsterList[i].GetBaseDamage() + monsterList[i].GetDamage();
            
            if (damage > defense[i])
            {
                damage = damage - defense[i];
                hp -= damage;
            }
            girl.SetCurrentHP(hp);
        }

        BattleStatus();
    }

    void GirlState()
    {
        for (int i = 0; i < allyAction.Length; i++)
        {
            allyAction[i].Behavior();
            Debug.Log("Uncontrollable" + " : " + allyAction[i]);
        }

        myState = BattleState.MONSTER;
    }

    void BattleStatus()
    {
        if (ContinueBattle())
        {
            // back to selection state if girl is not dead or monster is alive
            // disable self
            this.enabled = false;
            GameStateManager.Instance.SetGameState(GameState.SELECTION_PHASE);
        }
        else
        {
            // battle end
            GameStateManager.Instance.SetGameState(GameState.BATTLE_END);
            // disable this script
            this.enabled = false;
            // switch camera back
            GameStateManager.Instance.NormalCamera();
            // For debug
            Debug.Log("Battle End!");
        }
    }

    // check alive condition for both monster and girl
    bool ContinueBattle()
    { 
        // girl still alive
        if(girl.GetCurrentHP() > 0)
        {
            // AND monster is alive
            for (int i = 0; i < monsterList.Count; i++)
            {
                if (monsterList[i].GetMyHP() > 0)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
