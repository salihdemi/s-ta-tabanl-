using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    public string _name;
    private float maxHealth;
    private float baseAttackPower;
    public float speed;
    private float currentHealth;

    private Animator animator;

    [HideInInspector]
    public UnityEvent Lunge;

    private CharacterActionPanel characterActionPanel;

    private List<Skill> skills = new List<Skill>();

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterActionPanel = transform.GetChild(0).GetComponent<CharacterActionPanel>();
    }

    public void ClearLunge()
    {
        Lunge.RemoveAllListeners();
    }

    public void DecreaseHealth(float damage)
    {
        if (currentHealth > damage)
        {
            currentHealth -= damage;
        }
        else
        {
            currentHealth = 0;
            //öl
        }
        //ui da göster
    }

    public void OpenPanel()
    {
        characterActionPanel.gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        characterActionPanel.gameObject.SetActive(false);
        FightManager.instance.OpenNextCharacterPannel();
    }

    public void Atatck()
    {
    }

    public void Subs(Skill skill)//Buton
    {
        //secili saldýrýyý yap
        Lunge.AddListener(() => skill.Method(this));

        //Karakter animasyonu oynat

        ClosePanel();
    }


    public void LearnSkill(Skill skill)
    {
        Debug.Log(skill.ToString());
        if(skills.Contains(skill))
        {
            Debug.Log("bu skill zaten öðrenilmiþ");
            return;
        }
        Debug.Log("Skill öðrenliyor");
        skills.Add(skill);
        //characterActionPanel.AddSkill(skill);
    }
}
