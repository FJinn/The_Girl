using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEncounterController : MonoBehaviour
{
    // array that hold monster game object
    [SerializeField] GameObject[] monsterGO;
    // array for define new monster
    Monster[] monsterArray = new Monster[4];

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Random number
        int monsterNum = Random.Range(2, 4);
        // clear targetList
        BattleSelectionController.targetList.Clear();
        // clear monsterList
        BattlePhaseController.monsterList.Clear();
        // creates monsters and link it to gameObject
        for(int i=0; i<monsterNum; i++)
        {
            BattleNPC m = new BattleNPC(1, 1, (ElementType) Random.Range (0,3), (ElementType) Random.Range(0, 3));
            monsterArray[i] = (Monster)m;
            monsterGO[i].GetComponent<MonsterController>().SetMonster(monsterArray[i]);
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
