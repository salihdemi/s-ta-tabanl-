using UnityEngine;

[CreateAssetMenu(fileName = "Slice", menuName = "Scriptable Objects/Skills/Slice")]
public class Slow : _Skill
{
    public override void Method(CharacterBase user, CharacterBase target)
    {
        Debug.Log(user.name + " " + target.name + "'e " + name + " saldýrýsý yaptý");

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
        target.ChangeSpeed(-user.GetPower());
    }
}
