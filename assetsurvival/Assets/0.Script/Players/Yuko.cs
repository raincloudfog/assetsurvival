using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuko : Player
{
    // Start is called before the first frame update
    public override void Init()
    {
        //ü�� 80
        // ���ǵ� 7
        // ������ 0.5
        // ���� ������ 1.25��
        MaxHP = 80;
        Hp = 80;
        speed = 7f;
        delay = 0.5f;
        damagePlus = 1.25f;
        CriticalChance = 0.2f;
        CriticalPlus = 2.0f;
    }

    
}
