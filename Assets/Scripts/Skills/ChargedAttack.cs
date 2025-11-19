using UnityEngine;

[CreateAssetMenu(fileName = "ChargedAttack", menuName = "Scriptable Objects/Skills/ChargedAttack")]
public class ChargedAttack : _Skill
{
    public override void Method(CharacterBase user, CharacterBase target)
    {
        Debug.Log(user.name + " " + target.name + "'e " + name + " saldýrýsý yaptý");

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
        target.GetDamage(user.baseAttackPower / 2);
    }
}
