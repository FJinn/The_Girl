using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    NORMAL,
    KNOWLEDGE_PANEL,
    ENCOUNTER,
    PREPARATION,
    SELECTION_PHASE,
    /// <summary>
    /// phase where animations play and damage is dealt and counted
    /// </summary>
    BATTLE_PHASE,
    /// <summary>
    /// phase where experience is shown and so on
    /// </summary>
    BATTLE_END,
    NONE
}

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance;
    public static GameStateManager Instance { get { return instance; } }

    // cache girl controller
    GirlController girl;
    // temp to get camera
    Camera cam;
    // temp ori pos
    Vector3 ori;

    [SerializeField] GameState myGameState;

    // temp for debug
    public GameObject knowledgePanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        cam = Camera.main;
        // cache girl controller
        girl = GirlController.Instance;
    }

    private void Update()
    {
        // call related state function
        switch (myGameState)
        {
            case GameState.SELECTION_PHASE:
                SelectionPhase();
                break;
            case GameState.BATTLE_PHASE:
                BattlePhase();
                break;
            case GameState.BATTLE_END:
                BattleEnd();
                break;
            case GameState.NORMAL:
                break;
        }

        // bring out knowledge UI
        if(Input.GetKeyDown(KeyCode.K))
        {
            // temporary key
            if (myGameState == GameState.NORMAL)
            {
                knowledgePanel.SetActive(true);
                myGameState = GameState.KNOWLEDGE_PANEL;
            }
            else if (myGameState == GameState.KNOWLEDGE_PANEL)
            {
                knowledgePanel.SetActive(false);
                myGameState = GameState.NORMAL;
            }
        }
    }

    public void SetGameState(GameState newGameState)
    {
        myGameState = newGameState;
    }

    public GameState GetGameState()
    {
        return myGameState;
    }

    void PreparePhase()
    {
        // reserve for effect or something else
    }

    void SelectionPhase()
    {
        // for player to select ally, target, and action
       girl.GetBattleSelectionController().enabled = true;
    }

    void BattlePhase()
    {
        // to display attack and count the math
        girl.GetBattlePhaseController().enabled = true;
    }

    void BattleEnd()
    {
        // enable UI and battle result
        girl.GetBattleEndController().enabled = true;
    }

    public void BattleCamera()
    {
        // cache current position
        ori = cam.transform.position;
        // switch camera position
        cam.transform.position = new Vector3(5.5f, 9.3f, -10f);
    }

    public void NormalCamera()
    {
        // switch camera position back to normal
        cam.transform.position = ori;
    }
}