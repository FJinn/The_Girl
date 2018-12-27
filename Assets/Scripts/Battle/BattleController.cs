using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    enum SelectionState
    {
        ALLY,
        ACTION,
        UNCONTROLLABLE,
        NONE
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
        // set state = none
        currentState = SelectionState.NONE;
        // state will be UNCONTROLLABLE if girl emotion is over 100 and uncontrollable
        CheckUncontrollableAction();
        // else state will still be none and runs selectAlly and chooseAction functions
        if(currentState == SelectionState.NONE)
        {
            currentState = SelectionState.ALLY;
        }
    }

    private void Update()
    {   
        if(currentState == SelectionState.ALLY)
        {
            SelectAlly();
        }
        else if(currentState == SelectionState.ACTION)
        {
            ChooseAction();
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
            // store selected ally from the index
            selectedAlly = allyList[indexOfAlly];
            // add selected and stored ally into selectedAllyList for further function or add action respectively
            selectedAllyList.Add(selectedAlly);
            currentState = SelectionState.ACTION;
        }
    }

    private void ChooseAction()
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
                // Normal Attack

            }
            else if(actionChoice == 1)
            {
                // Normal Defend

            }
            else if(actionChoice == 2)
            {
                // Use Knowledge

            }
            else if(actionChoice == 3)
            {
                // Run
                // Increase Emotion level to Max
                GirlController.Instance.SetEmotionLevel(GirlController.MAX_EMOTIONLEVEL);
                // End battle
                GameStateManager.Instance.SetGameState(GameState.BATTLE_END);
                gameObject.SetActive(false);
            }
            currentState = SelectionState.ALLY;

            // after chose action, check if the selected ally list contains more or equal to ally list
            // if correct, end the phase and disable self
            if(selectedAllyList.Count >= allyList.Count)
            {
                GameStateManager.Instance.SetGameState(GameState.BATTLE_PHASE);
                gameObject.SetActive(false);
            }
        }
    }

    // check if girl emotion stable
    void CheckUncontrollableAction()
    {
        // cache Girl controller
        GirlController girl = GirlController.Instance;
        // check eq level
        float girlEmotion = girl.GetEmotionLevel();

        // if eq level higher or equal to x
        if (girlEmotion >= GirlController.MAX_EMOTIONLEVEL)
        {
            if (girl.GetEmotionType() == EmotionType.ANGRY)
            {
                myAction = new UncontrollableAngry();
            }
            else if (girl.GetEmotionType() == EmotionType.HAPPY)
            {
                myAction = new UncontrollableHappy();
            }
            else if (girl.GetEmotionType() == EmotionType.SAD)
            {
                myAction = new UncontrollableSad();
            }
            else if (girl.GetEmotionType() == EmotionType.SCARE)
            {
                myAction = new UncontrollableScare();
            }

            // disable choose ally and choose action
            currentState = SelectionState.UNCONTROLLABLE;
        }
    }
}
