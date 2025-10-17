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


    //public UnityEvent Lunge;


    public Button x;

    /*public void ClearLunge()
    {
        Lunge.RemoveAllListeners();
        Lunge.AddListener(ClearLunge);
    }*/
    public void DecreaseHealth(float damage)
    {
        if (currentHealth > damage)
        {
            currentHealth -= damage;
        }
        else
        {
            currentHealth = 0;
            //�l
        }
        //ui da g�ster
    }
    public void OpenPanel()
    {
        x.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        x.gameObject.SetActive(false);
        NewBehaviourScript.instance.OpenNextCharacterPannel();
    }
    public void Atatck()
    {
        Debug.Log(name + " " + baseAttackPower + " " + "hasar vurdu");
    }

    public void subs()
    {
        NewBehaviourScript.instance.UnityEvent.AddListener(Atatck);
        ClosePanel();
    }
}
