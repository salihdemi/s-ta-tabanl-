using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Ally", menuName = "Scriptable Objects/Characters/Ally")]
public class Ally : CharacterBase
{
    public _Skill attack;


    public Sprite _sprite;//inherit almak daha doðru olur ama denedim olmadý!




    public override void Play()
    {
        CharacterActionPanel.instance.WriteThings(this);

        CharacterActionPanel.instance.gameObject.SetActive(true);
    }

    public override void Over()
    {
        CharacterActionPanel.instance.gameObject.SetActive(false);
        CharacterActionPanel.instance.DisableAllPanels();

        //button.onClick.AddListener(() => skillsPanel.SetActive(false));
        FightManager.instance.CheckNextCharacter();
    }



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
