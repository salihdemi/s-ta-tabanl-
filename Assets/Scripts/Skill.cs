using UnityEditor;
using UnityEngine;
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

        FightManager.instance.animator.Play("New Animation");
        //animasyonu oynat
        //animator.SetBool("IsAttacking", true);

        //saldýrýyý yap
        //Debug.Log(name + " " + baseAttackPower + " " + "hasar vurdu");
    }
}
