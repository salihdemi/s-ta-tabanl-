using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Characters/Enemy")]
public class Enemy : CharacterBase
{
    public Sprite _sprite;//inherit almak daha doðru olur ama denedim olmadý
    public Profile profile;





    public override void SetLunge(_Skill skill)
    {
        //secili saldýrýyý iþaretle
        Lunge.AddListener(() => skill.Method(this, null));//!

        Over();
    }

    public override void Play()
    {
        //Random hamle ver
        _Skill currentskill = skills[Random.Range(0, skills.Count - 1)];
        //SetLunge
        SetLunge(currentskill);
    }

    public override void Over()
    {
        FightManager.instance.CheckNextCharacter();
    }
}
