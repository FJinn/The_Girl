using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AllyTypes
{
    TYPE1,
    TYPE2,
    TYPE3
};
public class BattleNPC : MonoBehaviour
{

    [SerializeField] ElementType myStrength;
    [SerializeField] ElementType myWeakness;
    [SerializeField] float damage;
    [SerializeField] string defense;

    public List<Ally> allies = new List<Ally>();
    AllyFactory aFactory = new AllyFactory();

    private void Awake()
    {
        allies.Add(aFactory.GetAlly(AllyTypes.TYPE1));
        allies.Add(aFactory.GetAlly(AllyTypes.TYPE2));
        allies.Add(aFactory.GetAlly(AllyTypes.TYPE3));

    }

}
public class AllyFactory
{
    public Ally GetAlly(AllyTypes allyType)
    {
        switch(allyType)
        {
            case AllyTypes.TYPE1:
                return new AllyType1();
            case AllyTypes.TYPE2:
                return new AllyType2();
            case AllyTypes.TYPE3:
                return new AllyType3();
            default:
                return new AllyType1();
        }
    }

}

public interface Ally
{
    // abstract interface class.
    void CalculateDamageReduced();
    void SetBaseDamage();
    void SetBaseDefense();
   
}

[System.Serializable]
public class AllyType1 : Ally
{
    public float baseDamage;
    public float baseDefense;
    public float totalDamageReduced;
    public AllyTypes type;
    public AllyType1()
    {


        type = AllyTypes.TYPE1;
    }
    public void CalculateDamageReduced() { }
    public void SetBaseDamage() { }
    public void SetBaseDefense() { }

}
[System.Serializable]
public class AllyType2 : Ally
{
    public float baseDamage;
    public float baseDefense;
    public float totalDamageReduced;
    public AllyTypes type;
    public AllyType2()
    {


        type = AllyTypes.TYPE2;
    }
    public void CalculateDamageReduced() { }
    public void SetBaseDamage() { }
    public void SetBaseDefense() { }
}
[System.Serializable]
public class AllyType3 : Ally
{
    public float baseDamage;
    public float baseDefense;
    public float totalDamageReduced;
    public AllyTypes type;
    public AllyType3()
    {


        type = AllyTypes.TYPE3;
    }
    public void CalculateDamageReduced() { }
    public void SetBaseDamage() { }
    public void SetBaseDefense() { }
}



