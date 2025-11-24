using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Profile : MonoBehaviour
{
    public Button button;
    public CharacterBase character;


    private float currentPower;
    private float currentSpeed;


    [HideInInspector] public Action<Profile, Profile> Lunge;
    [HideInInspector] public Profile Target;//fonksiyon içi deðiþken olabilir belki



    private float currentHealth;







    public abstract void Play();
    public abstract void Over();
    public void ResetStats()
    {
        currentPower = character.basePower;
        currentSpeed = character.baseSpeed;
    }
    public abstract void SetLunge(_Skill skill);
    public abstract void OpenPickTargetMenu(_Skill skill);
    public void ClearLungeAndTarget()
    {
        Lunge = null;
        Target = null;
    }
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
        if (currentHealth > character.maxHealth)
        {
            currentHealth = character.maxHealth;
        }
        if (currentHealth < 0)
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



    public float GetPower()
    {
        return currentPower;
    }
    public float GetSpeed()
    {
        return currentSpeed;
    }
}
