using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public Button button;
    public CharacterBase character;

    private void Awake()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener()
    }
}
