using System;
using System.Collections;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;
    FightManager()
    {
        instance = this;
    }

    private CharacterBase[] Characters = new CharacterBase[] { };
    private int characterOrder;

    //public Animator animator;


    [SerializeField] private Image[] AllyProfiles;
    [SerializeField] private Transform EnemyProfileParent;
    [SerializeField] private Image EnemyProfile;


    public void StartFight(Enemy[] enemies)
    {
        gameObject.SetActive(true);



        //Karakterleri diz
        for (int i = 0; i < MainCharacterMoveable.instance.party.Length; i++)
        {
            Ally ally = MainCharacterMoveable.instance.party[i];

            if (ally == null) continue;

            AllyProfiles[i].sprite = ally._sprite;
        }

        //Düþmanlarý diz
        foreach (Enemy enemy in enemies)
        {
            Image profile = Instantiate(EnemyProfile, EnemyProfileParent);
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
        Debug.Log(Characters);
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
        Debug.Log(Characters[characterOrder - 1] + " hamlesini seçiyor");
        Characters[characterOrder - 1].Play();
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
