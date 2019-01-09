using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleIndicatorController : MonoBehaviour
{
    public GameObject[] pointers;

    public void SelectingOneTarget(int index)
    {
        for(int i=0; i< pointers.Length; i++)
        {
            if(i == index)
            {
                pointers[i].SetActive(true);
            }
            else
            {
                pointers[i].SetActive(false);
            }
        }
    }
}
