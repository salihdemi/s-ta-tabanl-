using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Skills/Attack")]
public class Attack : _Skill
{
    public override void Method(CharacterBase user, CharacterBase target)
    {

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap

        target.ChangeHealth(-user.GetPower());
        Debug.Log(user.name + " " + target.name + "'a " + name + " ile " + user.GetPower() + " hasar verdi");
    }
}
