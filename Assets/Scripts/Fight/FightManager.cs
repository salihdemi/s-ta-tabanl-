using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;
    FightManager()
    {
        instance = this;
    }

    private CharacterBase[] Characters = new CharacterBase[] { };
    private Enemy[] Enemies = new Enemy[] { };
    private int characterOrder;

    //public Animator animator;


    [SerializeField] private Image[] AllyProfiles;
    [SerializeField] private Transform EnemyProfileParent;
    [SerializeField] private Image EnemyProfile;
    [SerializeField] private Image EnemyProfilePrefab;
    private List<Image> EnemyProfiles = new List<Image>();


    public void StartFight(Enemy[] enemies)
    {
        gameObject.SetActive(true);


        Enemies = enemies;
        //Karakterleri diz
        for (int i = 0; i < MainCharacterMoveable.instance.party.Length; i++)
        {
            Ally ally = MainCharacterMoveable.instance.party[i];

            if (ally == null) continue;

            AllyProfiles[i].sprite = ally._sprite;
        }

        //Düþmanlarý diz
        foreach (Enemy enemy in Enemies)
        {
            Image profile = Instantiate(EnemyProfilePrefab, EnemyProfileParent);
            EnemyProfiles.Add(profile);
            profile.sprite = enemy._sprite;
        }




        Characters = enemies.Cast<CharacterBase>().Concat(MainCharacterMoveable.instance.party.Where(p => p != null).Cast<CharacterBase>()).ToArray();




        StartTour();
    }
    public void LoseFight()
    {
        //ölüm ekraný* vs
    }
    public void FinishFight()
    {
        //Ödül ver*
        Characters = new CharacterBase[] { };
        ClearEnemies();

        gameObject.SetActive(false);
    }



    public void StartTour()
    {
        SortWithSpeed();
        characterOrder = 0;
        CheckNextCharacter();
    }
    private void SortWithSpeed()
    {
        Array.Sort(Characters, (a, b) => b.speed.CompareTo(a.speed));
    }
    public void CheckNextCharacter()
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
            LetNextPlayertoPlay();
        }
    }
    private void LetNextPlayertoPlay()
    {
        Debug.Log(Characters[characterOrder - 1]._name + " hamlesini seçiyor");
        Characters[characterOrder - 1].Play();
    }
    private void ClearEnemies()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            Destroy(EnemyProfiles[i].gameObject);
        }
        EnemyProfiles.Clear();
        Enemies = new Enemy[] {};
    }


    private IEnumerator Play()
    {
        Debug.Log("Oynat");
        foreach (CharacterBase item in Characters)
        {
            item.Lunge.Invoke();
            item.ClearLunge();
            yield return new WaitForSeconds(1);
        }
        StartTour();
    }


}
