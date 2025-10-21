using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    public string _name;
    private float maxHealth;
    private float baseAttackPower;
    public float speed;
    private float currentHealth;

    public Animator animator;

    public UnityEvent Lunge;


    public Button x;

    public Skill skill;

    public void ClearLunge()
    {
        Lunge.RemoveAllListeners();
    }
    public void DecreaseHealth(float damage)
    {
        if (currentHealth > damage)
        {
            currentHealth -= damage;
        }
        else
        {
            currentHealth = 0;
            //öl
        }
        //ui da göster
    }
    public void OpenPanel()
    {
        x.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        x.gameObject.SetActive(false);
        FightManager.instance.OpenNextCharacterPannel();
    }
    public void Atatck()
    {
    }
    public void Subs()//Buton
    {
        //secili saldýrýyý yap
        Lunge.AddListener(skill.Method);

        //Karakter animasyonu oynat

        ClosePanel();
    }
}
