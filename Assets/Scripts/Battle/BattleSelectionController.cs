using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSelectionController : MonoBehaviour
{
    enum SelectionState
    {
        ALLY,
        ACTION,
        UNCONTROLLABLE,
        TARGET,
        NONE
    }
    [SerializeField] SelectionState currentState;

    // Ally
    [SerializeField] BattleNPC selectedAlly;
    // ally that has been selected for battle action
    public static List<BattleNPC> selectedAllyList;
    // current active ally 
    private List<BattleNPC> allyList;
    // Target list
    public static List<BattleNPC> targetList;
    // cache which ally is currently selected by player
    private int indexOfAlly;
    private int actionChoice;
    // index for myAction
    int indexOfAction;
    // index for target
    int indexOfTarget;
    // action target number
    public static int actionTargetNumber;

    // Action
    public static Action[] myAction;

    private void Awake()
    {
        GirlController.Instance.SetBattleSelectionController(this);
    }

    private void OnEnable()
    {
        allyList = GirlController.allyList;
        // set myAction number
        myAction = new Action[allyList.Count];
        // add ally into target list
        for(int i=0; i<allyList.Count; i++)
        {
            targetList.Add(allyList[i]);
        }
        indexOfAlly = 0;
        actionChoice = 0;
        // index for myAction
        indexOfAction = 0;
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
        else if(currentState == SelectionState.TARGET)
        {
            for (int i = 0; i < actionTargetNumber; i++)
            {
                ChooseTarget();
            }
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
            // remove selected ally from allyList
            allyList.RemoveAt(indexOfAlly);
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
                myAction[indexOfAction] = new Attack();
                myAction[indexOfAction].thisNPC = selectedAlly;
            }
            else if(actionChoice == 1)
            {
                // Normal Defend
                myAction[indexOfAction] = new Defend();
                myAction[indexOfAction].thisNPC = selectedAlly;
            }
            else if(actionChoice == 2)
            {
                // Use Knowledge
                myAction[indexOfAction] = new UseKnowledge();
                myAction[indexOfAction].thisNPC = selectedAlly;
            }
            else if(actionChoice == 3)
            {
                // Run
                myAction[indexOfAction] = new Run();
                // Deactivate game object as battle ends
                gameObject.SetActive(false);
            }
            currentState = SelectionState.TARGET;

            // increase index of action
            indexOfAction++;

            // after chose action, check if the selected ally list contains more or equal to ally list
            // if correct, end the phase and disable self
            if(selectedAllyList.Count >= allyList.Count)
            {
                GameStateManager.Instance.SetGameState(GameState.BATTLE_PHASE);
                gameObject.SetActive(false);
            }
        }
    }

    void ChooseTarget()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (indexOfTarget == 0)
            {
                indexOfTarget = targetList.Count - 1;
            }
            else
            {
                indexOfTarget -= 1;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (indexOfTarget == targetList.Count - 1)
            {
                indexOfTarget = 0;
            }
            else
            {
                indexOfTarget += 1;
            }
        }

        // select target(s)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            myAction[indexOfAction].SetTarget(targetList[indexOfTarget]);
            currentState = SelectionState.ALLY;
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
                myAction[indexOfAction] = new UncontrollableAngry();
            }
            else if (girl.GetEmotionType() == EmotionType.HAPPY)
            {
                myAction[indexOfAction] = new UncontrollableHappy();
            }
            else if (girl.GetEmotionType() == EmotionType.SAD)
            {
                myAction[indexOfAction] = new UncontrollableSad();
            }
            else if (girl.GetEmotionType() == EmotionType.SCARE)
            {
                myAction[indexOfAction] = new UncontrollableScare();
            }

            // disable choose ally and choose action
            currentState = SelectionState.UNCONTROLLABLE;
            // skip to battle phase and disable game object
            GameStateManager.Instance.SetGameState(GameState.BATTLE_PHASE);
            gameObject.SetActive(false);
        }
    }
}
