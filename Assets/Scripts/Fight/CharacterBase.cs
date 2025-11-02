using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class CharacterBase : ScriptableObject
{
    public string _name;
    private float maxHealth;
    private float baseAttackPower;
    public float speed;
    private float currentHealth;

    [HideInInspector]
    public UnityEvent Lunge;


    public List<Skill> skills = new List<Skill>();



    public void ClearLunge()
    {
        Lunge.RemoveAllListeners();
    }




    public abstract void  Play();
    public abstract void Over();
    public abstract void SetLunge(Skill skill);

    
}
