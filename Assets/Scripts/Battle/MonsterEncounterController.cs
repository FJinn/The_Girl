using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEncounterController : MonoBehaviour
{
    // array that hold monster game object
    [SerializeField] GameObject[] monsterGO = new GameObject[4];
    // array for define new monster
    Monster[] monsterArray = new Monster[4];
    // cache girl controller
    GirlController girl;

    private void Awake()
    {
        girl = GirlController.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == girl.gameObject)
        {
            // Random number
            int monsterNum = Random.Range(2, 4);
            // clear targetList
            if (BattleSelectionController.targetList != null)
            {
                BattleSelectionController.targetList.Clear();
            }
            else
            {
                // initialize
                BattleSelectionController.targetList = new List<BattleNPC>();
            }
            // clear monsterList
            if (BattlePhaseController.monsterList != null)
            {
                BattlePhaseController.monsterList.Clear();
            }
            else
            {
                // initialize
                BattlePhaseController.monsterList = new List<Monster>();
            }
            // creates monsters and link it to gameObject
            for (int i = 0; i < monsterNum; i++)
            {
                Monster m = new Monster(1, 1, (ElementType)Random.Range(0, 3), (ElementType)Random.Range(0, 3));
                m.SetMyHP(10);
                monsterArray[i] = m;
                monsterGO[i].GetComponent<MonsterController>().SetMonster(monsterArray[i]);
                monsterGO[i].GetComponent<MonsterController>().enabled = true;
                // add into battle controller static list
                BattleSelectionController.targetList.Add(monsterArray[i]);
                // add into monsterList
                BattlePhaseController.monsterList.Add(monsterArray[i]);
            }
            // Enable battle selection controller
            GirlController.Instance.GetBattleSelectionController().enabled = true;

            // set game state to selection phase
            GameStateManager.Instance.SetGameState(GameState.SELECTION_PHASE);
        }
    }
}
