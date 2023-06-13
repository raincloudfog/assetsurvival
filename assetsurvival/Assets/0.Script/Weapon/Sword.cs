using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    
    
    private void OnEnable()
    {
        
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Hp -= WeaponManager.Instance.Hammerdamage;

        }
    }

}
