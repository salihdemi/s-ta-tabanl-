using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class CharacterBase : MonoBehaviour
{
    public string _name;
    private float maxHealth;
    private float baseAttackPower;
    public float speed;
    private float currentHealth;

    private Animator animator;

    [HideInInspector]
    public UnityEvent Lunge;


    public List<Skill> skills = new List<Skill>();


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ClearLunge()
    {
        Lunge.RemoveAllListeners();
    }




    public abstract void  Play();
    public abstract void Over();
    public abstract void SetLunge(Skill skill);

    
}
