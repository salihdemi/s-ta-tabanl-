using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Characters/Enemy")]
public class Enemy : CharacterBase
{
    Enemy()
    {
        //Heal();
        //profile.ResetStats();
    }

    public override void MakeProfile()
    {
        profile = FightManager.instance.MakeEnemyProfile();
        profile.character = this;
        profile.gameObject.name = name;
    }
}
