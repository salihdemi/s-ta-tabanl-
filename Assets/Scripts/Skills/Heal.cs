using UnityEngine;

[CreateAssetMenu(fileName = "Burst", menuName = "Scriptable Objects/Skills/Burst")]
public class Heal : _Skill
{
    public override void Method(CharacterBase user, CharacterBase target)
    {

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap
        target.ChangeHealth(target.GetPower() * 3);
        Debug.Log(user.name + " " + target.name + "'i " + name + " ile " + user.GetPower() * 3 + " iyileþtirdi");
    }
}
