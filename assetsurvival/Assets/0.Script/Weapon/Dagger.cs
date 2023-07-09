using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{

    Vector3 shootDirection; // 날아갈 방향
    float timer;

    float[] Crichance = new float[] { 50, 50 };

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

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            float Crichance = Choose(this.Crichance);
            if (other.GetComponent<ZombieHIt>() == true)
            {
                ZombieHIt enemy = other.GetComponent<ZombieHIt>();

                if (Crichance == 0)
                {
                    normaldamagetxt();
                    
                    enemy.zombieHit(WeaponManager.Instance.Daggerdamage * player.damagePlus);
                }
                else if(Crichance == 1)
                {
                    Cridamagetxt();
                    enemy.zombieHit(WeaponManager.Instance.Daggerdamage * (critPower + player.CriticalPlus + player.damagePlus));
                    Debug.Log("Dagger 크리티컬!!");
                }

            }
            else if (other.GetComponent<BossTree>() == true)
            {
                BossTree boss = other.GetComponent<BossTree>();
                
                
                if (Crichance == 0)
                {
                    normaldamagetxt();
                    
                    boss.Hit(WeaponManager.Instance.Daggerdamage * player.damagePlus);
                }
                else if(Crichance == 1)
                {
                    Cridamagetxt();

                    boss.Hit(WeaponManager.Instance.Daggerdamage *
                        (critPower + player.CriticalPlus + player.damagePlus));
                    Debug.Log("Dagger 크리티컬!!");
                }
            }
            ObjectPool.Instance.daggersreturn(this);
        }
    }
    
    protected override float Choose(float[] probs)
    {
        float total = 0;
        foreach (float item in probs)
        {
            total += item;
        }

        float randomPoint = Random.value * total;
        for (int i = 0; i < probs.Length; i++)
        {
            if(randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    void normaldamagetxt()
    {
        DamageTxtScript obj = ObjectPool.Instance.txtDequeue();
        obj.transform.position = transform.position;
        obj.transform.SetParent(null);
        obj.txt.text = (WeaponManager.Instance.Daggerdamage * (player.damagePlus)).ToString();
    }

    void Cridamagetxt()
    {
        DamageTxtScript obj = ObjectPool.Instance.txtDequeue();
        obj.transform.position = transform.position;
        obj.transform.SetParent(null);
        obj.txt.text = (WeaponManager.Instance.Daggerdamage * (critPower + player.CriticalPlus + player.damagePlus)).ToString();
    }

}
