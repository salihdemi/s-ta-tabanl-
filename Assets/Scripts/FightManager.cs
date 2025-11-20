using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;
    FightManager()
    {
        instance = this;
    }

    private CharacterBase[] Characters = new CharacterBase[] { };
    public Ally[] Allies = new Ally[] { };
    public Enemy[] Enemies = new Enemy[] { };

    private int characterOrder;

    //public Animator animator;

    [SerializeField] private Image ProfilePrefab;
    [SerializeField] private Transform AllyProfileParent;
    [SerializeField] private Transform EnemyProfileParent;
    private List<Image>  AllyProfiles = new List<Image>();
    private List<Image> EnemyProfiles = new List<Image>();


    public void StartFight(Enemy[] enemies)
    {
        if(MainCharacterMoveable.instance.party.Length < 1)
        {
            Debug.LogError("Parti boþ");
            return;
        }
        if (enemies.Length < 1)
        {
            Debug.LogError("Düþman partisi boþ");
            return;
        }


        gameObject.SetActive(true);


        //Dostlarý diz
        Allies = MainCharacterMoveable.instance.party;
        foreach (Ally ally in Allies)
        {
            Image profile = Instantiate(ProfilePrefab, AllyProfileParent);
            AllyProfiles.Add(profile);
            profile.sprite = ally._sprite;
        }

        //Düþmanlarý diz
        Enemies = enemies;
        foreach (Enemy enemy in Enemies)
        {
            Image profileImage = Instantiate(ProfilePrefab, EnemyProfileParent);
            EnemyProfiles.Add(profileImage);
            profileImage.sprite = enemy._sprite;


            Profile profile = profileImage.GetComponent<Profile>();
            profile.character = enemy;
            enemy.profile = profile;
        }




        Characters = Enemies.Cast<CharacterBase>().Concat(Allies.Where(p => p != null).Cast<CharacterBase>()).ToArray();




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
        ClearCharacters();

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
        Array.Sort(Characters, (a, b) => b.currentSpeed.CompareTo(a.currentSpeed));
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
        Debug.Log(Characters[characterOrder - 1].name + " hamlesini seçiyor");
        Characters[characterOrder - 1].Play();
    }
    private void ClearCharacters()
    {
        Debug.Log(AllyProfiles);
        for (int i = 0; i < AllyProfiles.Count; i++)
        { Destroy(AllyProfiles[i].gameObject); }
        AllyProfiles.Clear();

            
        for (int i = 0; i < EnemyProfiles.Count; i++)
        { Destroy(EnemyProfiles[i].gameObject); }
        EnemyProfiles.Clear();
    }


    private IEnumerator Play()
    {
        Debug.Log("Oynat");
        foreach (CharacterBase item in Characters)
        {
            item.Lunge(item, item.target);
            item.ClearLungeAndTarget();
            yield return new WaitForSeconds(1);
        }
        StartTour();
    }


    /*
    public void PickCharacterState()
    {

        //düþman butonlarýný aç
        foreach (Enemy item in Enemies)
        {
            Enemies[0].profile.button.interactable = true;
        }
    }*/
}
