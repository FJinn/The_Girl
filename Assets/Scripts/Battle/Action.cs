using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public virtual void Behavior(GameObject go)
    {

    }

    public virtual void Display()
    {

    }
}

public class ControllableAction : Action
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class Attack : ControllableAction
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class Defend : ControllableAction
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UseSkill : ControllableAction
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class Run : ControllableAction
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableAction : Action
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableHappy : UncontrollableAction
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableSad : UncontrollableAction
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableScare : UncontrollableAction
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}

public class UncontrollableAngry : UncontrollableAction
{
    public override void Behavior(GameObject go)
    {
        base.Behavior(go);
    }

    public override void Display()
    {
        base.Display();
    }
}


