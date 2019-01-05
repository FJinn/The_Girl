using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    Monster myMonster;
    SpriteRenderer mySR;

    private void OnEnable()
    {
        // turn on sprite renderer
        mySR.enabled = true;
    }

    private void Awake()
    {
        mySR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // if hp drops to 0
        KillSelf();
    }

    public Monster GetMonster()
    {
        return myMonster;
    }

    public void SetMonster(Monster monster)
    {
        myMonster = monster;
    }

    // disable self when monster hp is < 0
    void KillSelf()
    {
        if (myMonster.GetMyHP() <= 0)
        {
            // turn off sprite
            mySR.enabled = false;
            // disable self
            this.enabled = false;
        }
    }
}
