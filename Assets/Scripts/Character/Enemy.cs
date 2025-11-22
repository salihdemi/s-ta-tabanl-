using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Characters/Enemy")]
public class Enemy : CharacterBase
{





    #region Fight
    public override void Play()
    {
        _Skill currentskill = skills[Random.Range(0, skills.Count - 1)]; //Random hamle ver
        SetLunge(currentskill);
    }

    public override void Over()
    {
        FightManager.instance.CheckNextCharacter();
    }
    public override void SetLunge(_Skill skill)
    {
        Lunge = skill.Method;//secili saldýrýyý iþaretle

        PickTarget(skill);//Hedef seçme ekranýný aç
    }
    public override void PickTarget(_Skill skill)
    {
        Target = MainCharacterMoveable.instance.party[0];//default hedef!

        Over();
    }
    #endregion
}
