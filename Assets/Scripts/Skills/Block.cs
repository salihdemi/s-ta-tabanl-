using UnityEngine;

[CreateAssetMenu(fileName = "Block", menuName = "Scriptable Objects/Skills/Block")]
public class Block : _Skill
{
    public override void Method(CharacterBase user, CharacterBase target)
    {

        //animasyonu oynat
        //sesi oynat

        //saldýrýyý yap

        user.ChangeHealth(user.GetPower());
        Debug.Log(user.name + " " + target.name + "'i " + name + " ile " + user.GetPower() + " iyileþtirdi");
    }
}
