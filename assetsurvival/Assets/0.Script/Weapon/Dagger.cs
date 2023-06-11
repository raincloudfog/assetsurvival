using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{

    Vector3 shootDirection;

    public override void Init()
    {
        base.Init();
        
    }

    public void setVec(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
    }

    public override void Attack()
    {
        
        rigid.velocity = shootDirection * 5;
    }

    private void FixedUpdate()
    {
        Attack();
    }
}
