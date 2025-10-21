using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/Skill")]
public class Skill : ScriptableObject
{
    public Animation animation;
    [SerializeField]
    public Button x;
    public void Method(CharacterBase user)
    {
        Debug.Log(user.name + " " + name);
        //animasyonu oynat
        //animator.SetBool("IsAttacking", true);

        //saldýrýyý yap
        //Debug.Log(name + " " + baseAttackPower + " " + "hasar vurdu");
    }
}
