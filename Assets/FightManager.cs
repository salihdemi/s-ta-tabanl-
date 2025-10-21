using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;
    FightManager()
    {
        instance = this;
    }

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
        foreach (CharacterBase item in Characters)
        {
            item.ClearLunge();
        }
        SortWithSpeed();
        characterOrder = 0;
        OpenNextCharacterPannel();
    }

    private void Update()
    {
        //Debug.Log(Characters[0].Lunge);
    }

    public void OpenNextCharacterPannel()
    {

        if (characterOrder == Characters.Length)
        {
            Debug.Log("tüm hamleler yapýldý");
            //oynat
            StartCoroutine(Play());
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

    private IEnumerator Play()
    {
        foreach (CharacterBase item in Characters)
        {
            item.Lunge.Invoke();
            yield return new WaitForSeconds(1);
        }
        StartTour();
    }


}
