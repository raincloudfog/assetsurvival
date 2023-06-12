using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{

    Vector3 shootDirection; // 날아갈 방향

    public override void Init()
    {
        weapons = Weapons.Dagger;

        base.Init();
        
    }

    public void setVec(Vector3 shootDirection) // 위치값 가져옴
    {
        this.shootDirection = shootDirection;
    }

    public override void Attack() // 어택은 픽시드 업데이트로 실행됨
    {
        
        rigid.velocity = shootDirection * 5;
    }

    private void FixedUpdate()
    {
        Attack();
    }
}
