using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovementController : MonoBehaviour
{
    // cache girl controller
    GirlController girl;
    // cache game state
    GameStateManager gsm;
    Rigidbody2D rb2d;

    // value
    [SerializeField] float walkSpeed;
    const float MAX_WALK_SPEED = 10;

    private void Awake()
    {
        girl = GirlController.Instance;
        // set this to girl controller
        girl.SetMovementController(this);
        // cache game state manager
        gsm = GameStateManager.Instance;
        // cache rigid body
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(gsm.GetGameState() == GameState.NORMAL)
        {
            Walk();
        }
        else
        {
            // need to change if cutscene is needed
            rb2d.velocity = Vector2.zero;
        }
    }

    void Walk()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            float tempSpeed = rb2d.velocity.x - walkSpeed;
            if(tempSpeed < -MAX_WALK_SPEED)
            {
                tempSpeed = -MAX_WALK_SPEED;
            }
            rb2d.velocity = new Vector2(tempSpeed, rb2d.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            float tempSpeed = rb2d.velocity.x + walkSpeed;
            if (tempSpeed > MAX_WALK_SPEED)
            {
                tempSpeed = MAX_WALK_SPEED;
            }
            rb2d.velocity = new Vector2(tempSpeed, rb2d.velocity.y);
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
}
