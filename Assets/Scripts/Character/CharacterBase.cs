
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterBase : ScriptableObject
{

    //burada base deðerler olacak, iþlenmiþ deðerler scriptable objectin dýþýnda olmalý
    public string _name;
    private float maxHealth;
    private float baseAttackPower;
    public float speed;
    private float currentHealth;

    [HideInInspector]
    public UnityEvent Lunge;


    public List<_Skill> skills = new List<_Skill>();



    public void ClearLunge()
    {
        Lunge.RemoveAllListeners();
    }




    public abstract void  Play();
    public abstract void Over();
    public abstract void SetLunge(_Skill skill);

    
}
