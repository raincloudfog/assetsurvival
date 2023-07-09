using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    Collider[] colliders;

    float[] CriChance = new float[] { 70, 30 };

    public override void Init()
    {
        base.Init();
        weapons = Weapons.Sword;
       
        WeaponSpeed = 3f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }

    

    private void FixedUpdate()
    {
        Attack();

        
    } 
    // 이 코드 OnTriggerStay로 할수도 있음.
    public override void Attack()
    {
        colliders = Physics.OverlapSphere(transform.position, 2, LayerMask.GetMask("Enemy"));
        foreach (Collider item in colliders)
        {
            if (item.GetComponent<ZombieHIt>() != null)
            {
                float Cri = Choose(CriChance);

                ZombieHIt zombieHIt = item.GetComponent<ZombieHIt>();
                if(Cri == 0)
                {
                    zombieHIt.zombieHit(WeaponManager.Instance.Sworddamage * Time.deltaTime * player.damagePlus);
                }
                else if(Cri == 1)
                {
                    zombieHIt.zombieHit(WeaponManager.Instance.Sworddamage * Time.deltaTime *
                        (critPower + player.CriticalPlus + player.damagePlus));
                    Debug.Log("Sword 크리티컬!!");
                }


            }
            else if (item.GetComponent<BossTree>() == true)
            {
                float Cri = Choose(CriChance);
                BossTree boss = item.GetComponent<BossTree>();
                if(Cri == 0)
                {
                    boss.Hit(WeaponManager.Instance.Sworddamage * Time.deltaTime * player.damagePlus);
                }
                else if(Cri == 1)
                {
                    boss.Hit(WeaponManager.Instance.Sworddamage * Time.deltaTime *
                        (critPower + player.CriticalPlus + player.damagePlus));
                    Debug.Log("Sword 크리티컬!!");
                }
            }
        }
    }

    protected override float Choose(float[] probs)
    {
        float total = 0;
        foreach (float item in probs)
        {
            total += item;
        }

        float randomPoint = total * Random.value;

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
        obj.txt.text = (WeaponManager.Instance.Sworddamage * (player.damagePlus)).ToString();
    }

    void Cridamagetxt()
    {
        DamageTxtScript obj = ObjectPool.Instance.txtDequeue();
        obj.transform.position = transform.position;
        obj.transform.SetParent(null);
        obj.txt.text = (WeaponManager.Instance.Sworddamage * (critPower + player.CriticalPlus + player.damagePlus)).ToString();
    }



}
