using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan : Player
{
    public override void Init()
    {
        //�⺻ü�� 100
        // ���ǵ� 5
        // ���� ������ 1
        // �� ���� 1.5��
        Hp = 100;
        speed = 5f;
        delay = 1;
        damagePlus = 1.5f;
    }
    

    
}
