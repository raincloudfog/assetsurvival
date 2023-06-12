using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{

    Vector3 shootDirection; // ���ư� ����

    public override void Init()
    {
        weapons = Weapons.Dagger;

        base.Init();
        
    }

    public void setVec(Vector3 shootDirection) // ��ġ�� ������
    {
        this.shootDirection = shootDirection;
    }

    public override void Attack() // ������ �Ƚõ� ������Ʈ�� �����
    {
        
        rigid.velocity = shootDirection * 5;
    }

    private void FixedUpdate()
    {
        Attack();
    }
}
