using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    NORMAL,
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

    [SerializeField] GameState myGameState;

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

    }
}