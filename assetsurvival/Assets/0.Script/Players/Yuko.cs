using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuko : Player
{
    // Start is called before the first frame update
    public override void Init()
    {
        //체력 80
        // 스피드 7
        // 딜레이 0.5
        // 무기 딜증가 1.25배
        MaxHP = 80;
        Hp = 80;
        speed = 7f;
        delay = 0.5f;
        damagePlus = 1.25f;
        CriticalChance = 0.2f;
        CriticalPlus = 2.0f;
    }

    
}
