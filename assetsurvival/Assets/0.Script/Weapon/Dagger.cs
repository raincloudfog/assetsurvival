using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{

    Vector3 shootDirection; // ���ư� ����
    float timer;

    public override void Init()
    {
        base.Init();
        weapons = Weapons.Dagger;
        transform.localRotation = Quaternion.Euler(90,0,0);
        transform.localPosition = Vector3.zero;
       
        
        
        WeaponSpeed = 3f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
        
        
    }
    

    public void setVec(Vector3 shootDirection) // ��ġ�� ������
    {
        this.shootDirection = shootDirection;
    }

    public override void Attack() // ������ �Ƚõ� ������Ʈ�� �����
    {
        
        rigid.velocity = shootDirection * 10;
    }

    
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            timer = 0;

            ObjectPool.Instance.daggersreturn(this); // ������ �����ش�.
            //Destroy(gameObject, 2f);
        }
        Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Hp -= WeaponManager.Instance.Daggerdamage;
            ObjectPool.Instance.daggersreturn(this); // ������ �����ش�.
        }
    }

}
