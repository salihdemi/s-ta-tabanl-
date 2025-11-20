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
        Lunge = skill.Method;

        PickTarget(skill);
    }

    public override void PickTarget(_Skill skill)
    {

        Target = MainCharacterMoveable.instance.party[0];//default hedef!

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
