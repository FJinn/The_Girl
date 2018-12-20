using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    // Ally
    [SerializeField] Ally selectedAlly;
    [SerializeField] List<Ally> selectedAllyList;
    private List<Ally> allyList;
    // cache which ally is currently selected by player
    private int indexOfAlly;

    // Action
    Action myAction;

    private void OnEnable()
    {
        allyList = GirlController.Instance.GetAllyList();
        indexOfAlly = 0;
    }

    private void Update()
    {
        selectedAlly = allyList[indexOfAlly];
        SelectAlly();
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //ChooseAction(selectedAlly);
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
    }

    private void ChooseAction(Ally ally)
    {

    }
}
