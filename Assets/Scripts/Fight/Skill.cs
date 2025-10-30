using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/Skill")]
public class Skill : ScriptableObject
{
    //[SerializeField]
    //private AnimationClip clip;
    //public Button x;
    Skill()
    { 

    }
    public void Method(CharacterBase user)
    {
        Debug.Log(user.name + " " + name);

        //FightManager.instance.animator.Play("New Animation");
        //animasyonu oynat
        //animator.SetBool("IsAttacking", true);

        //saldýrýyý yap
        //Debug.Log(name + " " + baseAttackPower + " " + "hasar vurdu");
    }

    public void AddButton(Ally character, GameObject skillsPanel)
    {
        //Buton
        GameObject newSkillButton = new GameObject(name + "_Button");
        newSkillButton.transform.parent = skillsPanel.transform.GetChild(0);
        newSkillButton.AddComponent<CanvasRenderer>();
        newSkillButton.AddComponent<Image>();
        Button button = newSkillButton.AddComponent<Button>();


        //Text
        GameObject ButtonText = new GameObject("text");
        ButtonText.transform.parent = newSkillButton.transform;
        TextMeshProUGUI text = ButtonText.AddComponent<TextMeshProUGUI>();
        text.text = name;
        text.color = Color.black;
        //text.fontSize = 12;

        //Buton event
        button.onClick.AddListener(() => character.SetLunge(this));
        button.onClick.AddListener(() => skillsPanel.SetActive(false));
    }
}
