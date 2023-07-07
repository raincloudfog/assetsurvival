using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    Collider[] colliders;
    /*private void OnEnable()
    {
        
    }*/

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
    public override void Attack()
    {
        colliders = Physics.OverlapSphere(transform.position, 2, LayerMask.GetMask("Enemy"));
        foreach (Collider item in colliders)
        {
            if (item.GetComponent<ZombieHIt>() != null)
            {
                Debug.Log("좀비를 소드로 때리는 중");
                ZombieHIt zombieHIt = item.GetComponent<ZombieHIt>();
                zombieHIt.zombieHit(WeaponManager.Instance.Hammerdamage * Time.deltaTime);
                
            }
            else if (item.GetComponent<BossTree>() == true)
            {
                BossTree boss = item.GetComponent<BossTree>();
                boss.Hit(WeaponManager.Instance.Hammerdamage);
            }
        }
    }

    




}
