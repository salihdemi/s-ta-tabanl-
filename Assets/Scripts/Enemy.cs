using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    public override void SetLunge(Skill skill)
    {

    }

    public override void Play()
    {
        Debug.Log(name + "hamle yapt�");
        //Random hamle ver
        //SetLunge
        Over();
    }

    public override void Over()
    {
        FightManager.instance.LetPlayNextCharacter();
    }
}
