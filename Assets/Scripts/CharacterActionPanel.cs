using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterActionPanel : MonoBehaviour
{
    private CharacterBase character;

    private TextMeshProUGUI nameText;
    private Transform buttonsParent;
    private Transform panelsParent;

    private Button attackButton;
    private Button skillsButton;
    private Button foodsButton;
    private Button toysButton;

    private GameObject skillsPanel;
    private GameObject foodsPanel;
    private GameObject toysPanel;

    private Transform x;
    private void Start()
    {
        character = GetComponentInParent<CharacterBase>();
        FindFirstChilds();
        FindButtons();
        FindPanels();

        WriteName();

        AssignButtons();
    }
    private void FindFirstChilds()
    {
        nameText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        buttonsParent = transform.GetChild(1);
        panelsParent = transform.GetChild(2);
    }
    private void FindButtons()
    {
        attackButton = buttonsParent.GetChild(0).GetComponent<Button>();
        skillsButton = buttonsParent.GetChild(1).GetComponent<Button>();
        foodsButton = buttonsParent.GetChild(2).GetComponent<Button>();
        toysButton = buttonsParent.GetChild(3).GetComponent<Button>();
    }
    private void FindPanels()
    {
        skillsPanel = panelsParent.GetChild(0).gameObject;
        foodsPanel = panelsParent.GetChild(1).gameObject;
        toysPanel = panelsParent.GetChild(2).gameObject;

        x=skillsPanel.transform.GetChild(0);
    }
    private void WriteName()
    {
        nameText.text = character.name;
    }

    private void AssignButtons()
    {
        skillsButton.onClick.AddListener(() => skillsPanel.SetActive(true));
        foodsButton.onClick.AddListener(() => foodsPanel.SetActive(true));
        toysButton.onClick.AddListener(() => toysPanel.SetActive(true));
    }

    public void DisableAllPanels()
    {
        skillsPanel.SetActive(false);
        foodsPanel.SetActive(false);
        toysPanel.SetActive(false);
    }
    /*public void AddSkill(Skill skill)
    {
        //Buton
        GameObject newSkillButton = new GameObject(skill.name + "_Button");
        //newSkillButton.transform.parent = skillsPanel.transform.GetChild(0);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        newSkillButton.transform.parent = x;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        newSkillButton.AddComponent<CanvasRenderer>();
        newSkillButton.AddComponent<Image>();
        Button button = newSkillButton.AddComponent<Button>();

        //Text
        GameObject ButtonText = new GameObject("text");
        ButtonText.transform.parent = newSkillButton.transform;
        Text text= ButtonText.AddComponent<Text>();
        text.text = skill.name;
        
        //Buton event
        button.onClick.AddListener(() => skill.Method(character));
        button.onClick.AddListener(() => skillsPanel.SetActive(false));
    }
    */
}
