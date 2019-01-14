using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySelectionEffectController : MonoBehaviour
{
    public GameObject[] pointers;
    // cache girl controller
    GirlController girl;
    int allyNumber;

    private void Awake()
    {
        girl = GirlController.Instance;
    }
    
    public void SelectingOneTarget(int index)
    {
        allyNumber = girl.GetAllyList().Count;

        for (int i = 0; i < allyNumber; i++)
        {
            if (i == index)
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
