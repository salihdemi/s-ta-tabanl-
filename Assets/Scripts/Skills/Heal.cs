using UnityEngine;

[CreateAssetMenu(fileName = "Burst", menuName = "Scriptable Objects/Skills/Burst")]
public class Heal : _Skill
{
    public override void Method(CharacterBase user, CharacterBase target)
    {
        Debug.Log(user.name + " " + target.name + "'e " + name + " saldýrýsý yaptý");

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
        target.ChangeHealth(target.GetPower() * 3);
    }
}
