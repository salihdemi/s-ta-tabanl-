
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
    public UnityEvent Lunge;


    public List<_Skill> skills = new List<_Skill>();



    public void ClearLunge()
    {
        Lunge.RemoveAllListeners();
    }




    public abstract void  Play();
    public abstract void Over();
    public  void SetLunge(_Skill skill)
    {
        //secili saldýrýyý iþaretle
        Lunge.AddListener(() => skill.Method(this, null));//!

        Over();
    }


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
