using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionEffectController : MonoBehaviour
{
    GirlController girl;
    // drag in inspector
    public GameObject[] skillObjects;
    // cache objects sprite renderers
    SpriteRenderer[] skillSprites;
    // cache mid point of sr
    int midPoint;
    // cache girl skill list
    List<Knowledge> skills;

    private void Awake()
    {
        // cache girl
        girl = GirlController.Instance;
        // initiate sprite renderer
        skillSprites = new SpriteRenderer[skillObjects.Length];
        // calculate mid point
        midPoint = skillObjects.Length / 2;
        // cache sprite renderer
        for(int i=0; i<skillObjects.Length; i++)
        {
            skillSprites[i] = skillObjects[i].GetComponent<SpriteRenderer>();
        }
        // cache girl skill list
        skills = girl.GetSkillList();
    }

    public void ChangeSprite(int currentOption)
    {
        // change skill sprite
        skillSprites[midPoint].sprite = skills[currentOption].GetSprite();

        for(int i=0; i< skillObjects.Length; i++)
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
                if (temp < skills.Count)
                {
                    skillSprites[i].sprite = skills[temp].GetSprite();
                }
                else
                {
                    skillSprites[i].sprite = null;
                }
                // first skill, so stops at this skill
                if(temp == 0 && i == 0 && currentOption != 1)
                {
                    skillSprites[i].sprite = null;
                }
            }
        }
    }

    // enable all sprite object
    public void ActivateSpriteObjects()
    {
        for(int i=0; i<skillObjects.Length; i++)
        {
            skillObjects[i].SetActive(true);
        }
    }

    // disable all sprite object
    public void DeactivateSpriteObjects()
    {
        for (int i = 0; i < skillObjects.Length; i++)
        {
            skillObjects[i].SetActive(false);
        }
    }
}
