using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    public static NewBehaviourScript instance;

    NewBehaviourScript()
    {
        instance = this;
    }

    public UnityEvent UnityEvent;
    public CharacterBase[] Characters;
    public int characterOrder;

    private void Start()
    {
        StartFight();
    }
    public void StartFight()
    {
        //UI aç
        StartTour();
    }
    public void StartTour()
    {
        SortWithSpeed();
        characterOrder = 0;
        OpenNextCharacterPannel();
    }
    private void Update()
    {
        Debug.Log(characterOrder);
    }
    public void OpenNextCharacterPannel()
    {

        if (characterOrder == Characters.Length)
        {
            Debug.Log("tüm hamleler yapıldı");
            //oynat
            UnityEvent.Invoke();
            StartTour();
        }
        else
        {

            Characters[characterOrder].OpenPanel();
            characterOrder++;
        }
    }
    private void SortWithSpeed()
    {
        Array.Sort(Characters, (a, b) => b.speed.CompareTo(a.speed));
    }


}
