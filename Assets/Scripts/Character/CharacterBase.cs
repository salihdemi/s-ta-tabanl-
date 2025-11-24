
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterBase : ScriptableObject
{

    //burada base deðerler olacak, iþlenmiþ deðerler scriptable objectin dýþýnda olmalý
    [Header("Stats")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float basePower;
    [SerializeField] private float baseSpeed;
    //stamina
    //mana
    //kalkan
    //zýrh

    private float currentHealth;
    private float currentPower;
    private float currentSpeed;

    [HideInInspector] public Action<CharacterBase, CharacterBase> Lunge;
    [HideInInspector] public CharacterBase Target;


    [Header("Visuals")]
    public Sprite _sprite;


    [Header("Skills")]
    public List<_Skill> skills = new List<_Skill>();


    [HideInInspector] public Profile profile;

    #region ResetStats
    public void Heal()
    {
        currentHealth = maxHealth;
    }
    public void ResetStats()
    {
        currentPower = basePower;
        currentSpeed = baseSpeed;
    }
    #endregion




    #region FightLoop
    public abstract void Play();
    public abstract void Over();
    public abstract void SetLunge(_Skill skill);
    public abstract void OpenPickTargetMenu(_Skill skill);

    public void ClearLungeAndTarget()
    {
        Lunge = null;
        Target = null;
    }

    #endregion






    #region Fight
    public void ForceChangeHealth(float amount)//Overhealth
    {
        currentHealth += amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            //öl


            //herkes öldü mü diye kontrol et
        }
        //yaz
    }
    public void ChangeHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        //yaz
    }
    public void ChangePower(float amount)
    {
        currentPower += amount;
    }
    public void ChangeSpeed(float amount)
    {
        currentSpeed += amount;
    }
    public bool IsDied()
    {
        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion


    #region Encapsulation
    public float GetHealth()
    {
        return currentHealth;
    }
    public float GetPower()
    {
        return currentPower;
    }
    public float GetSpeed()
    {
        return currentSpeed;
    }
    #endregion

}
