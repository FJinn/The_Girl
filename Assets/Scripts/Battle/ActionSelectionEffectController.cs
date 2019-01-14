using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectionEffectController : MonoBehaviour
{
     GirlController girl;
    // drag in inspector
    public GameObject[] actionObjects;
    // cache objects sprite renderers
    SpriteRenderer[] mySprites;
    // cache available action sprites
    public Sprite[] actionSprites;
    // cache mid point of sr
    int midPoint = 1;

    private void Awake()
    {
        // cache girl
        girl = GirlController.Instance;
        // initiate sprite renderer
        mySprites = new SpriteRenderer[actionObjects.Length];
        // cache sprite renderer
        for(int i=0; i<actionObjects.Length; i++)
        {
            mySprites[i] = actionObjects[i].GetComponent<SpriteRenderer>();
        }
    }

    public void ChangeSprite(int currentOption)
    {
        // change action sprite
        mySprites[midPoint].sprite = actionSprites[currentOption];

        for(int i=0; i< actionObjects.Length; i++)
        {
            // skip midPoint
            if(i != midPoint)
            {
                int temp = currentOption - midPoint + i;
                if(temp < 0)
                {
                    temp = 0;
                }

                // not rotating skills, so it will stop at first and last skill
                if (temp < actionSprites.Length)
                {
                    mySprites[i].sprite = actionSprites[temp];
                }
                else
                {
                    mySprites[i].sprite = null;
                }
                // first skill, so stops at this skill
                if(temp == 0 && i == 0 && currentOption != 1)
                {
                    mySprites[i].sprite = null;
                }
            }
        }
    }

    // enable all sprite object
    public void ActivateSpriteObjects()
    {
        for(int i=0; i<actionObjects.Length; i++)
        {
            actionObjects[i].SetActive(true);
        }
    }

    // disable all sprite object
    public void DeactivateSpriteObjects()
    {
        for (int i = 0; i < actionObjects.Length; i++)
        {
            actionObjects[i].SetActive(false);
        }
    }
}
