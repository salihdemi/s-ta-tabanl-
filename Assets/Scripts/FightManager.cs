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
        //UI aç
        //Karakterleri diz
        StartTour();
    }

    public void StartTour()
    {
        ClearLunges();
        SortWithSpeed();
        characterOrder = 0;
        LetPlayNextCharacter();
    }
    private void ClearLunges()
    {
        foreach (CharacterBase item in Characters)
        {
            item.ClearLunge();
        }
    }
    public void LetPlayNextCharacter()//daha düzgün fonksiyonla
    {

        if (characterOrder == Characters.Length)
        {
            Debug.Log("tüm hamleler yapýldý");
            //oynat
            StartCoroutine(Play());
        }
        else
        {
            characterOrder++;
            Characters[characterOrder-1].Play();
        }
    }

    private void SortWithSpeed()
    {
        Array.Sort(CharactersSortedWithSpeed, (a, b) => b.speed.CompareTo(a.speed));
    }

    private IEnumerator Play()
    {
        foreach (CharacterBase item in CharactersSortedWithSpeed)
        {
            item.Lunge.Invoke();
            yield return new WaitForSeconds(1);
        }
        StartTour();
    }


}
