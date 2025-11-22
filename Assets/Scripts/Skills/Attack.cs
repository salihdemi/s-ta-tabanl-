using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Skills/Attack")]
public class Attack : _Skill
{
    public override void Method(CharacterBase user, CharacterBase target)
    {
        Debug.Log(user.name + " " + target.name + "'e " + name + " saldýrýsý yaptý");

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
        target.ChangeHealth(-user.GetPower());
    }
}
