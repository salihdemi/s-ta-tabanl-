using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Ally", menuName = "Scriptable Objects/Ally")]
public class Ally : CharacterBase
{
    public Skill attack;


    public Sprite _sprite;//inherit almak daha doðru olur ama denedim olmadý



    public override void SetLunge(Skill skill)
    {
        //secili saldýrýyý iþaretle
        Lunge.AddListener(() => skill.Method(this));

        //Karakter animasyonu oynat

        Over();
    }

    public override void Play()
    {
        CharacterActionPanel.instance.gameObject.SetActive(true);
        CharacterActionPanel.instance.WriteThings(this);
    }

    public override void Over()
    {
        CharacterActionPanel.instance.gameObject.SetActive(false);
        FightManager.instance.CheckNextCharacter();
    }



    public void LearnSkill(Skill skill)
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
