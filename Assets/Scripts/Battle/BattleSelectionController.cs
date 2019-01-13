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
        SKILL_SELECTION,
        TARGET,
        NONE
    }
    [SerializeField] SelectionState currentState;

    // Ally
    [SerializeField] BattleNPC selectedAlly;
    // ally that has been selected for battle action
    public static List<BattleNPC> selectedAllyList;
    // ally list from girl
    private List<BattleNPC> allyList;
    // current active ally 
    private List<BattleNPC> currentAllyList;
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
    public int actionTargetNumber = 0;
    // selected knowledge
    Knowledge selectedKnowledge;
    // cache skill selection effect controller
    public SkillSelectionEffectController skillSelectionEffectController;
    // cache battle indicator controller
    public BattleIndicatorController battleIndicatorController;
    // index for knowledge/skill selection
    int knowledgeIndex = 0;

    // Action
    public static Action[] myAction;

    private void Awake()
    {
        GirlController.Instance.SetBattleSelectionController(this);
    }

    private void OnEnable()
    {
        allyList = GirlController.Instance.GetAllyList();
        // initialize current ally list
        if(currentAllyList == null)
        {
            currentAllyList = new List<BattleNPC>();
        }
        else
        {
            currentAllyList.Clear();
        }

        for(int i=0; i<allyList.Count; i++)
        {
            currentAllyList.Add(allyList[i]);
        }

        // set myAction number
        if (currentAllyList != null)
        {
            myAction = new Action[currentAllyList.Count];
            // done in monsterEncounterController
            //if(targetList != null)
            //{
            //    targetList.Clear();
            //}
            //else
            //{
            //    // initiate targetList
            //    targetList = new List<BattleNPC>();
            //}
            // initiate selected ally list
            if(selectedAllyList == null)
            {
                selectedAllyList = new List<BattleNPC>();
            }
            else
            {
                selectedAllyList.Clear();
            }
            // remove ally from target list
            //// add ally into target list
            //for (int i = 0; i < allyList.Count; i++)
            //{
            //    targetList.Add(allyList[i]);
            //}
            indexOfAlly = 0;
            actionChoice = 0;
            // index for myAction
            indexOfAction = 0;
            // set state = none
            currentState = SelectionState.NONE;
            // state will be UNCONTROLLABLE if girl emotion is over 100 and uncontrollable
            CheckUncontrollableAction();
            // else state will still be none and runs selectAlly and chooseAction functions
            if (currentState == SelectionState.NONE)
            {
                currentState = SelectionState.ALLY;
            }
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
        else if(currentState == SelectionState.SKILL_SELECTION)
        {
            if(GirlController.Instance.GetSkillList().Count > 0)
            {
                SelectKnowledge();
            }
            else
            {
                Debug.Log("Error, no skill!");
            }
        }
        else if(currentState == SelectionState.TARGET)
        {
        //    for (int i = 0; i < actionTargetNumber; i++)
        //    {
                ChooseTarget();
         //   }
        }
    }

    private void SelectAlly()
    {   
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(indexOfAlly == 0)
            {
                indexOfAlly = currentAllyList.Count-1;
            }
            else
            {
                indexOfAlly -= 1;
            }
            // debug
            Debug.Log("Up");
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            if(indexOfAlly == currentAllyList.Count-1)
            {
                indexOfAlly = 0;
            }
            else
            {
                indexOfAlly += 1;
            }
            // debug
            Debug.Log("Down");
        }
        // debug
        Debug.Log("Ally: " + indexOfAlly);

        if(Input.GetKeyDown(KeyCode.Z))
        {
            // store selected ally from the index
            selectedAlly = currentAllyList[indexOfAlly];
            // remove selected ally from allyList
            currentAllyList.RemoveAt(indexOfAlly);
            // add selected and stored ally into selectedAllyList for further function or add action respectively
            selectedAllyList.Add(selectedAlly);
            currentState = SelectionState.ACTION;
            
            // debug
            Debug.Log("Selected Ally: " + selectedAlly);
        }
    }

    private void ChooseAction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (actionChoice == 0)
            {
                actionChoice = 3;
            }
            else
            {
                actionChoice -= 1;
            }

            // debug
            Debug.Log("Up");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (actionChoice == 3)
            {
                actionChoice = 0;
            }
            else
            {
                actionChoice += 1;
            }

            // debug
            Debug.Log("Down");
        }
        // debug
        Debug.Log("Action: " + actionChoice);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(actionChoice == 0)
            {
                // Normal Attack
                myAction[indexOfAction] = new Attack(selectedAlly);
            }
            else if(actionChoice == 1)
            {
                // Normal Defend
                myAction[indexOfAction] = new Defend(selectedAlly);

                // if not the end of ally action, continue to another ally
                currentState = SelectionState.ALLY;

                // after chose action, check if the selected ally list contains more or equal to ally list
                // if correct, end the phase and disable self
                if (selectedAllyList.Count >= currentAllyList.Count)
                {
                    GameStateManager.Instance.SetGameState(GameState.BATTLE_PHASE);
                    this.enabled = false;
                }
                
                // quit running rest of the code since no need to choose target
                return;
            }
            else if(actionChoice == 2)
            {
                currentState = SelectionState.SKILL_SELECTION;

                return;
            }
            else if(actionChoice == 3)
            {
                // Run
                myAction[indexOfAction] = new Run(selectedAlly);
                // Deactivate this script as battle ends
                this.enabled = false;

                // quit running rest of the code since girl runs away
                // change to battle phase for run action
                GameStateManager.Instance.SetGameState(GameState.BATTLE_PHASE);
            }
            
            currentState = SelectionState.TARGET;

            // debug
            Debug.Log("Selected Action: " + myAction[indexOfAction]);
        }
    }

    void ChooseTarget()
    {
        battleIndicatorController.SelectingOneTarget(indexOfTarget);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (indexOfTarget == 0)
            {
                indexOfTarget = 0; // targetList.Count - 1;
            }
            else
            {
                indexOfTarget -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (indexOfTarget == targetList.Count - 1)
            {
                indexOfTarget = targetList.Count - 1; // 0;
            }
            else
            {
                indexOfTarget += 1;
            }
        }

        // select target(s)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            myAction[indexOfAction].AddTarget(targetList[indexOfTarget]);

            // increase index of action
            indexOfAction++;

            if (indexOfAction > myAction.Length)
            {
                indexOfAction = myAction.Length;
            }

            // off indicator
            battleIndicatorController.SelectingOneTarget(-1);

            currentState = SelectionState.ALLY;
            
            // after chose action, check if the selected ally list contains more or equal to ally list
            // if correct, end the phase and disable self
            if (selectedAllyList.Count >= currentAllyList.Count)
            {
                GameStateManager.Instance.SetGameState(GameState.BATTLE_PHASE);
                this.enabled = false;
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
            // skip to battle phase and disable this script
            GameStateManager.Instance.SetGameState(GameState.BATTLE_PHASE);
            this.enabled = false;
        }
    }

    // knowledge selection
    void SelectKnowledge()
    {
        // clear selected knowledge
        selectedKnowledge = null;
        GirlController girl = GirlController.Instance;
        // activate skill selection objects 
        skillSelectionEffectController.ActivateSpriteObjects();
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (knowledgeIndex == 0)
            {
                //  knowledgeIndex = girl.GetSkillList().Count - 1;
                // stop at index 0
                knowledgeIndex = 0;
            }
            else
            {
                knowledgeIndex--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (knowledgeIndex == girl.GetSkillList().Count - 1)
            {
                // knowledgeIndex = 0;
                // stop at last index
                knowledgeIndex = girl.GetSkillList().Count - 1;
            }
            else
            {
                knowledgeIndex++;
            }
        }

        // pass in knowledge index into skillSelectionEffectController
        skillSelectionEffectController.ChangeSprite(knowledgeIndex);

        // select skill/knowledge
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Use Knowledge
            myAction[indexOfAction] = new UseKnowledge(selectedAlly, selectedKnowledge);

            selectedKnowledge = girl.GetSkillList()[knowledgeIndex];
            skillSelectionEffectController.DeactivateSpriteObjects();
            
            currentState = SelectionState.TARGET;
        }
    }
}
