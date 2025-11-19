using UnityEngine;

[CreateAssetMenu(fileName = "Skill1", menuName = "Scriptable Objects/Skill1")]
public class Skill1 : _Skill
{
    public override void Method(CharacterBase user)
    {
        Debug.Log(user.name + ", " + name + " saldýrýsý yaptý");

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
    }
}
