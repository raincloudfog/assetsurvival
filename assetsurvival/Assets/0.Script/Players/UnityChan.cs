using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan : Player
{
    public override void Init()
    {
        //기본체력 100
        // 스피드 5
        // 무기 딜레이 1
        // 딜 증가 1.5배
        Hp = 100;
        speed = 5f;
        delay = 1;
        damagePlus = 1.5f;
    }
    

    
}
