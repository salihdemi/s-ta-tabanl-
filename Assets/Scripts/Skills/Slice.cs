using UnityEngine;

[CreateAssetMenu(fileName = "Slice", menuName = "Scriptable Objects/Skills/Slice")]
public class Slice : _Skill
{
    public override void Method(CharacterBase user)
    {
        Debug.Log(user.name + ", " + name + " saldýrýsý yaptý");

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
    }
}
