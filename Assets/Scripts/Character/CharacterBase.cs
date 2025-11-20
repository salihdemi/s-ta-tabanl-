
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

    [HideInInspector] public Action<CharacterBase, CharacterBase> Lunge;
    [HideInInspector] public CharacterBase Target;



    public List<_Skill> skills = new List<_Skill>();


    //public List<CharacterBase> team;
    //public List<CharacterBase> enemyTeam;

    public void ClearLungeAndTarget()
    {
        Lunge = null;
        Target = null;
    }




    public abstract void  Play();
    public abstract void Over();
    public abstract void SetLunge(_Skill skill);
    public abstract void PickTarget(_Skill skill);

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
