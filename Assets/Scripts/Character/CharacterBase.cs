
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterBase : ScriptableObject
{

    //burada base deðerler olacak, iþlenmiþ deðerler scriptable objectin dýþýnda olmalý
    public float maxHealth;
    public float health;
    public float baseAttackPower;
    public float currentAttackPower;
    public float baseSpeed;
    public float currentSpeed;

    [HideInInspector]
    public Action<CharacterBase, CharacterBase> Lunge;

    public CharacterBase target;

    public List<_Skill> skills = new List<_Skill>();



    public void ClearLungeAndTarget()
    {
        Lunge = null;
        target = null;
    }




    public abstract void  Play();
    public abstract void Over();
    public abstract void SetLunge(_Skill skill);


    public void GetDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            health = 0;
            //öl
            //herkes öldü mü diye kontrol et
        }
    }

    
}
