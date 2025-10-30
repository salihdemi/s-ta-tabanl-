using UnityEngine;

public class Ally : CharacterBase
{
    private CharacterActionPanel characterActionPanel;


    private void Awake()
    {
        characterActionPanel = transform.GetChild(0).GetComponent<CharacterActionPanel>();
    }


    public override void SetLunge(Skill skill)
    {
        //secili saldýrýyý yap
        Lunge.AddListener(() => skill.Method(this));

        //Karakter animasyonu oynat

        Over();
    }

    public override void Play()
    {
        characterActionPanel.gameObject.SetActive(true);
    }

    public override void Over()
    {
        characterActionPanel.gameObject.SetActive(false);
        FightManager.instance.LetPlayNextCharacter();
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
        characterActionPanel.AddSkill(skill);
    }
}
