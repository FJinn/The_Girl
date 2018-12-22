using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    enum SelectionState
    {
        ALLY,
        ACTION
    }
    [SerializeField] SelectionState currentState;

    // Ally
    [SerializeField] BattleNPC selectedAlly;
    [SerializeField] List<BattleNPC> selectedAllyList;
    private List<BattleNPC> allyList;
    // cache which ally is currently selected by player
    private int indexOfAlly;
    private int actionChoice;
    

    // Action
    Action myAction;

    private void OnEnable()
    {
        allyList = GirlController.Instance.GetAllyList();
        indexOfAlly = 0;
        actionChoice = 0;
        currentState = SelectionState.ALLY;
    }

    private void Update()
    {   
        if(currentState == SelectionState.ALLY)
        {
            selectedAlly = allyList[indexOfAlly];
            SelectAlly();
        }
        else if(currentState == SelectionState.ACTION)
        {
            ChooseAction(selectedAlly);
        }
    }

    private void SelectAlly()
    {   
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(indexOfAlly == 0)
            {
                indexOfAlly = allyList.Count-1;
            }
            else
            {
                indexOfAlly -= 1;
            }
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            if(indexOfAlly == allyList.Count-1)
            {
                indexOfAlly = 0;
            }
            else
            {
                indexOfAlly += 1;
            }
        }

        if(Input.GetKey(KeyCode.Z))
        {
            currentState = SelectionState.ACTION;
        }
    }

    private void ChooseAction(BattleNPC ally)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (actionChoice == 0)
            {
                actionChoice = 3;
            }
            else
            {
                actionChoice -= 1;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (actionChoice == 3)
            {
                actionChoice = 0;
            }
            else
            {
                actionChoice += 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(actionChoice == 0)
            {

            }
            else if(actionChoice == 1)
            {

            }
            else if(actionChoice == 2)
            {

            }
            else if(actionChoice == 3)
            {

            }
            currentState = SelectionState.ALLY;
        }
    }
}
