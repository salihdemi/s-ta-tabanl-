using System;
using System.Collections;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;
    FightManager()
    {
        instance = this;
    }

    [SerializeField] private CharacterBase[] Characters = new CharacterBase[] { };//serializefield gidecek
    public int characterOrder;

    public Animator animator;


    public void StartFight(Enemy[] enemies)//enemy parametresi alacak, belki ally de alabilir
    {
        gameObject.SetActive(true);
        //Karakterleri diz
        //D��manlar� diz




        Characters = enemies.Cast<CharacterBase>().Concat(MainCharacterMoveable.instance.party.Cast<CharacterBase>()).ToArray();




        StartTour();
    }
    public void LoseFight()
    {
        //�l�m ekran�* vs
    }
    public void FinishFight()
    {
        //�d�l ver*
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
        Array.Sort(Characters, (a, b) => b.speed.CompareTo(a.speed));
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
        foreach (CharacterBase item in Characters)
        {
            item.Lunge.Invoke();
            yield return new WaitForSeconds(1);
        }
        StartTour();
    }


}
