using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misaki : Player
{
    // Start is called before the first frame update
    public override void Init()
    {
        // ü�� 150
        // ���ǵ� 5
        // ������ 1
        // ������ 1��
        Hp = 150;
        speed = 5f;
        delay = 1f;
        damagePlus = 1f;
    }

    
}
