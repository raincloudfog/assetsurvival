using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{

    Vector3 shootDirection; // 날아갈 방향
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
    

    public void setVec(Vector3 shootDirection) // 위치값 가져옴
    {
        this.shootDirection = shootDirection;
    }

    public override void Attack() // 어택은 픽시드 업데이트로 실행됨
    {
        
        rigid.velocity = shootDirection * 10;
    }

    
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            timer = 0;

            ObjectPool.Instance.daggersreturn(this); // 본인을 없애준다.
            //Destroy(gameObject, 2f);
        }
        Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("무언가에는 닿였다."+ other.gameObject);
        if(other.gameObject.layer == 6)
        {
            Debug.Log("맞았다");
            ZombieHIt enemy = other.GetComponentInParent<ZombieHIt>();
            enemy.zombieHit(WeaponManager.Instance.Daggerdamage);
            ObjectPool.Instance.daggersreturn(this); // 본인을 없애준다.
        }
    }

}
