using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Ally", menuName = "Scriptable Objects/Characters/Ally")]
public class Ally : CharacterBase
{

    public _Skill attack;






    #region Fight
    public override void Play()
    {
        CharacterActionPanel.instance.WriteThings(this);

        CharacterActionPanel.instance.gameObject.SetActive(true);
    }
    public override void Over()
    {
        foreach (Profile profile in FightManager.instance.EnemyProfiles)
        {
            profile.button.interactable = false;
            profile.button.onClick.RemoveAllListeners();
        }

        foreach (Profile profile in FightManager.instance.AllyProfiles)
        {
            profile.button.interactable = false;
            profile.button.onClick.RemoveAllListeners();
        }

        CharacterActionPanel.instance.gameObject.SetActive(false);

        FightManager.instance.CheckNextCharacter();
    }
    public override void SetLunge(_Skill skill)
    {
        //secili saldýrýyý iþaretle
        Lunge = skill.Method;

        CharacterActionPanel.instance.DisableAllPanels();

        //hedef seçecek
        PickTarget(skill);
    }
    public override void PickTarget(_Skill skill)
    {
        if (skill.isToEnemy)
        {
            foreach (Profile profile in FightManager.instance.EnemyProfiles)
            {
                profile.button.interactable = true;
                profile.button.onClick.AddListener(() => SetTarget(profile));
            }
        }
        else
        {
            foreach (Profile profile in FightManager.instance.AllyProfiles)
            {
                profile.button.interactable = true;
                profile.button.onClick.AddListener(() => SetTarget(profile));
            }
        }
    }
    public void SetTarget(Profile profile)
    {
        Target = profile.character;

        Over();
    }
    #endregion


    public void LearnSkill(_Skill skill)
    {
        Debug.Log(skill.ToString());
        if(skills.Contains(skill))
        {
            Debug.Log("bu skill zaten öðrenilmiþ");
            return;
        }
        Debug.Log("Skill öðrenldi");
        skills.Add(skill);
    }

}
