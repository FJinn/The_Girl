using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    // target list
    public List<BattleNPC> myTargetList;
    protected BattleNPC thisNPC;

    // uncontrollable action constructor
    public Action() { }

    // controllable action constructor
    public Action(BattleNPC me)
    {
        thisNPC = me;

        if(myTargetList != null)
        {
            // clear target list in case myTargetList is the previous list
            myTargetList.Clear();
        }
        else
        {
            // initiate
            myTargetList = new List<BattleNPC>();
        }
        //reset defense point
        if(thisNPC.GetDefendBool() == true)
        {
            thisNPC.SetDefense(thisNPC.GetDefense() + 10);
            thisNPC.SetDefendBool(false);
        }
    }

    // set my target
    public void AddTarget(BattleNPC target)
    {
        myTargetList.Add(target);
    }

    public virtual void Behavior()
    {

    }

    public virtual void Display()
    {

    }
}

public class ControllableAction : Action
{
    public ControllableAction(BattleNPC me) : base(me)
    { }

    public override void Behavior()
    {
        base.Behavior();
    }

    public override void Display()
    {
        base.Display();
    }
}

class Attack : ControllableAction
{
    public Attack(BattleNPC me) : base(me)
    { }

    public override void Behavior()
    {
        base.Behavior();
        for(int i=0;i<myTargetList.Count;i++)
        {
            BattleNPC temp = myTargetList[i];
            Monster tempTarget = (Monster)temp;
            float hp = tempTarget.GetMyHP();
            float damage = thisNPC.GetBaseDamage() + thisNPC.GetDamage();
            float defense = tempTarget.GetBaseDefense() + tempTarget.GetDefense();
            if(damage > defense)
            {
                damage = damage - defense;
                hp -= damage;
            }
            tempTarget.SetMyHP(hp);
        }
    }

    public override void Display()
    {
        base.Display();
    }
}

public class Defend : ControllableAction
{
    public Defend(BattleNPC me) : base(me)
    { }

    public override void Behavior()
    {
        base.Behavior();
        thisNPC.SetDefense(thisNPC.GetDefense() + 10);
        thisNPC.SetDefendBool(true);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UseKnowledge : ControllableAction
{
    Knowledge thisKnowledge;

    public UseKnowledge(BattleNPC me, Knowledge k) : base(me)
    {
        thisKnowledge = k;
    }

    public override void Behavior()
    {
        base.Behavior();

        for (int i = 0; i < myTargetList.Count; i++)
        {
            BattleNPC temp = myTargetList[i];
            Monster tempTarget = (Monster)temp;
            float hp = tempTarget.GetMyHP();
            float damage = GirlController.Instance.GetEQ() + thisKnowledge.GetValue();
            float defense = tempTarget.GetBaseDefense() + tempTarget.GetDefense();
            if (damage > defense)
            {
                damage = damage - defense;
                hp -= damage;
            }
            tempTarget.SetMyHP(hp);
        }
    }

    public override void Display()
    {
        base.Display();
    }
}

public class Run : ControllableAction
{
    public Run(BattleNPC me) : base(me)
    { }

    public override void Behavior()
    {
        base.Behavior();

        // Increase Emotion level to Max
        GirlController.Instance.SetEmotionLevel(GirlController.MAX_EMOTIONLEVEL);
        // End battle
        GameStateManager.Instance.SetGameState(GameState.BATTLE_END);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableAction : Action
{
    public override void Behavior()
    {
        base.Behavior();
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableHappy : UncontrollableAction
{
    public override void Behavior()
    {
        base.Behavior();
        Debug.Log("I am HAPPY");
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableSad : UncontrollableAction
{
    public override void Behavior()
    {
        base.Behavior();
        Debug.Log("I am SAD");
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableScare : UncontrollableAction
{
    public override void Behavior()
    {
        base.Behavior();
        Debug.Log("I am SCARE");
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableAngry : UncontrollableAction
{
    public override void Behavior()
    {
        base.Behavior();
        Debug.Log("I am ANGRY");
    }

    public override void Display()
    {
        base.Display();
    }
}


