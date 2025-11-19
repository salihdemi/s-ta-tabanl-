using UnityEngine;

[CreateAssetMenu(fileName = "ChargedAttack", menuName = "Scriptable Objects/Skills/ChargedAttack")]
public class ChargedAttack : _Skill
{
    public override void Method(CharacterBase user)
    {
        Debug.Log(user.name + ", " + name + " saldýrýsý yaptý");

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
    }
}
