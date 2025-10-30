using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;
    FightManager()
    {
        instance = this;
    }

    [SerializeField]
    private CharacterBase[] Characters;
    private CharacterBase[] CharactersSortedWithSpeed;
    public int characterOrder;

    public Animator animator;

    private void Start()
    {
        CharactersSortedWithSpeed = Characters;
        StartFight();
    }

    public void StartFight()
    {
        //UI a�
        //Karakterleri diz
        StartTour();
    }

    public void StartTour()
    {
        ClearLunges();
        SortWithSpeed();
        characterOrder = 0;
        CheckNextCharacter();
    }
    private void ClearLunges()
    {
        foreach (CharacterBase item in Characters)
        {
            item.ClearLunge();
        }
    }
    public void CheckNextCharacter()//daha d�zg�n fonksiyonla
    {
        if (characterOrder == Characters.Length)
        {
            Debug.Log("t�m hamleler yap�ld�");
            //oynat
            StartCoroutine(Play());
        }
        else
        {
            characterOrder++;
            LetNextPlayertoPlay();
        }
    }
    private void LetNextPlayertoPlay()
    {
        Debug.Log(Characters[characterOrder - 1] + " hamlesini se�iyor");
        Characters[characterOrder - 1].Play();
    }

    private void SortWithSpeed()
    {
        Array.Sort(CharactersSortedWithSpeed, (a, b) => b.speed.CompareTo(a.speed));
    }

    private IEnumerator Play()
    {
        Debug.Log("Oynat");
        foreach (CharacterBase item in CharactersSortedWithSpeed)
        {
            item.Lunge.Invoke();
            yield return new WaitForSeconds(1);
        }
        StartTour();
    }


}
