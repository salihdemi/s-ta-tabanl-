using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class Enemy : CharacterBase
{



    public Sprite _sprite;//inherit almak daha doðru olur ama denedim olmadý


    public override void SetLunge(_Skill skill)
    {

    }

    public override void Play()
    {
        //Random hamle ver
        //SetLunge
        Over();
    }

    public override void Over()
    {
        FightManager.instance.CheckNextCharacter();
    }
}
