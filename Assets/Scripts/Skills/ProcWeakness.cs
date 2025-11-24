using UnityEngine;

[CreateAssetMenu(fileName = "ChargedAttack", menuName = "Scriptable Objects/Skills/ChargedAttack")]
public class ProcWeakness : _Skill
{
    public override void Method(CharacterBase user, CharacterBase target)
    {

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap

        target.ChangePower(-5);
        Debug.Log(user.name + " " + target.name + "'a " + name + " ile " + 5 + " zayýflattý");
    }
}
