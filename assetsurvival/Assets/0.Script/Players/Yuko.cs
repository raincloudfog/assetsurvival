using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuko : Player
{
    // Start is called before the first frame update
    void Start()
    {
        //ü�� 80
        // ���ǵ� 7
        // ������ 0.5
        // ���� ������ 1.25��
        Hp = 80;
        speed = 7f;
        delay = 0.5f;
        damagePlus = 1.25f;

    }

    
}
