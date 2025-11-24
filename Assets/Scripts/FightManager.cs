using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;
    FightManager()
    {
        instance = this;
    }
    private List<CharacterBase> Characters = new List<CharacterBase> { };


    //public Animator animator;
    [Header("Profiles")]
    [SerializeField] private Profile ProfilePrefab;
    [SerializeField] private Transform AllyProfileParent;
    [SerializeField] private Transform EnemyProfileParent;
    [HideInInspector] public List<Profile>  AllyProfiles = new List<Profile>();
    [HideInInspector] public List<Profile> EnemyProfiles = new List<Profile>();



    private int characterOrder;


    public void StartFight(Enemy[] enemies)//Fonksiyonla!
    {
        if(MainCharacterMoveable.instance.party.Length < 1)
        {Debug.LogError("Parti boþ");return; }
        if (enemies.Length < 1)
        {Debug.LogError("Düþman partisi boþ");return; }



        gameObject.SetActive(true);

        Ally[] allies = MainCharacterMoveable.instance.party;
                    //.Where(a => a.GetHealth() > 0)
                    //.ToArray();

        SortAllies(allies);
        SortEnemies(enemies);
        Characters = enemies
                    .Cast<CharacterBase>()
                    .Concat(allies
                    .Where(p => p != null)
                    .Cast<CharacterBase>())
                    .ToList();


        ResetStats();

        StartTour();
    }
    public void LoseFight()
    {
        //ölüm ekraný* vs
        //ClearCharacters();
    }
    public void FinishFight()
    {
        //Ödül ver*
        ClearCharacters();
        //moveable
        CharacterActionPanel.instance.gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }




    private void StartTour()
    {
        SortWithSpeed();
        characterOrder = 0;
        CheckNextCharacter();
    }
    private void SortWithSpeed()
    {
        Characters.Sort((a, b) => b.GetSpeed().CompareTo(a.GetSpeed()));
    }
    public void CheckNextCharacter()
    {
        if (characterOrder == Characters.Count)
        {
            Debug.Log("tüm hamleler yapýldý");
            
            StartCoroutine(Play());//oynat
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



    private void SortAllies(Ally[] allies)
    {
        //Dostlarý diz
        for (int i = 0; i < allies.Length; i++)
        {
            Ally ally = allies[i];

            Profile profile = Instantiate(ProfilePrefab, AllyProfileParent);
            Image profileImage = profile.GetComponent<Image>();

            //profil
            AllyProfiles.Add(profile);
            profile.character = ally;
            ally.profile = profile;
            profileImage.sprite = ally._sprite;
        }
    }
    private void SortEnemies(Enemy[] enemies)
    {
        //Düþmanlarý diz
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];

            Profile profile = Instantiate(ProfilePrefab, EnemyProfileParent);
            Image profileImage = profile.GetComponent<Image>();

            //profil
            EnemyProfiles.Add(profile);
            profile.character = enemy;
            enemy.profile = profile;
            profileImage.sprite = enemy._sprite;
        }
    }
    private void ResetStats()
    {
        for (int i = 0; i < Characters.Count; i++)
        {
            CharacterBase character = Characters[i];
            character.ResetStats();
        }
    }
    private void ClearCharacters()
    {
        Characters = new List<CharacterBase> { };

        for (int i = 0; i < AllyProfiles.Count; i++)
        { Destroy(AllyProfiles[i].gameObject); }
        AllyProfiles.Clear();

            
        for (int i = 0; i < EnemyProfiles.Count; i++)
        { Destroy(EnemyProfiles[i].gameObject); }
        EnemyProfiles.Clear();
    }


    public void CheckDie()
    {
        for (int i = 0; i < Characters.Count; i++)
        {
            CharacterBase character = Characters[i];
            if (character.IsDied())
            {
                if (character is Ally)
                {
                    KillAlly((Ally)character);
                }
                else if (character is Enemy)
                {
                    KillEnemy((Enemy)character);
                }
            }


        }
    }
    private void KillAlly(Ally ally)
    {
        Characters.Remove(ally);
        AllyProfiles.Remove(ally.profile);

        Destroy(ally.profile.gameObject);


        if (AllyProfiles.Count == 0)
        {
            LoseFight();
        }
        else
        {
            StartTour();
        }
    }
    private void KillEnemy(Enemy enemy)
    {
        Characters.Remove(enemy);
        EnemyProfiles.Remove(enemy.profile);

        Destroy(enemy.profile.gameObject);

        if(EnemyProfiles.Count == 0)
        {
            FinishFight();
        }
        else
        {
            StartTour();
        }
    }



    private IEnumerator Play()
    {
        Debug.Log("Oynat");
        for (int i = 0;i < Characters.Count; i++)
        {
            CharacterBase item = Characters[i];
            item.Lunge(item, item.Target);//Hamleyi yap
            item.ClearLungeAndTarget();//Hamleyi temizle

            yield return new WaitForSeconds(1);
        }

        CheckDie();

    }
}
