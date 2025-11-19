using UnityEngine;

[CreateAssetMenu(fileName = "Burst", menuName = "Scriptable Objects/Skills/Burst")]
public class Burst : _Skill
{
    public override void Method(CharacterBase user)
    {
        Debug.Log(user.name + ", " + name + " saldýrýsý yaptý");

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
    }
}
