using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misaki : Player
{
    // Start is called before the first frame update
    public override void Init()
    {
        // 체력 150
        // 스피드 5
        // 딜레이 1
        // 딜증가 1배
        MaxHP = 150;
        Hp = 150;
        speed = 5f;
        delay = 1f;
        damagePlus = 1f;
        CriticalChance = 0.2f;
        CriticalPlus = 2.0f;
    }

    
}
