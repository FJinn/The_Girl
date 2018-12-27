using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    Monster myMonster;
    
    public Monster GetMonster()
    {
        return myMonster;
    }

    public void SetMonster(Monster monster)
    {
        myMonster = monster;
    }
}
