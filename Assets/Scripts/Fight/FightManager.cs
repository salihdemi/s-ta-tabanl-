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

    [SerializeField] private CharacterBase[] Characters;
    private CharacterBase[] CharactersSortedWithSpeed;
    public int characterOrder;

    public Animator animator;

    private void Start()
    {
        CharactersSortedWithSpeed = Characters;
        StartFight();
    }

    public void StartFight()//enemy parametresi alacak, belki ally de alabilir
    {
        gameObject.SetActive(true);
        //Karakterleri diz
        //D��manlar� diz
        StartTour();
    }
    public void LoseFight()
    {

    }
    public void FinishFight()
    {
        //�d�l ver
        gameObject.SetActive(false);
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
    private void SortWithSpeed()
    {
        Array.Sort(CharactersSortedWithSpeed, (a, b) => b.speed.CompareTo(a.speed));
    }
    public void CheckNextCharacter()
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
