using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan : Player
{

    // Start is called before the first frame update
    void Start()
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
