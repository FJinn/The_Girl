using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEndController : MonoBehaviour
{
    // cache girl controller
    GirlController girl;
    // cache game state manager
    GameStateManager gsm;

    // game over UI
    public GameObject gameOverUI;
    // win result UI
    public GameObject battleResultUI;
    // timer to enable player to quit battle end phase
    int timer = 1;
    float counter = 0;
    // bool to cache game over
    bool isGameOver = false;

    private void Awake()
    {
        // cache girl controller
        girl = GirlController.Instance;
        // cache game state manager
        gsm = GameStateManager.Instance;

        // link to girl
        girl.SetBattleEndController(this);
    }

    private void Update()
    {
        if(isGameOver)
        {
            GameOver();
        }
        else
        {
            BattleResult();
        }
        // run timer once it gets enabled by game state manager
        QuitBattleEnd();
    }

    public void SetGameOver(bool value)
    {
        isGameOver = value;
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    void BattleResult()
    {
        battleResultUI.SetActive(true);
    }

    void QuitBattleEnd()
    {
        if(counter >= timer && Input.GetKeyDown(KeyCode.Z))
        {
            counter = 0;

            gameOverUI.SetActive(false);
            battleResultUI.SetActive(false);

            // set game state back to normal if not game over
            if (!isGameOver)
            {
                gsm.SetGameState(GameState.NORMAL);
            }
            else
            {
                // set none for now
                gsm.SetGameState(GameState.NONE);
            }

            this.enabled = false;
        }
        else
        {
            counter += Time.deltaTime;
        }
    }
}
