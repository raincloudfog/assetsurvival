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
        Damage = 10 * player.damagePlus;
        WeaponSpeed = 3f;
        Delay = 1f;
        critPower = 1.5f;
        critpersent = 0.5f;
    }

    

    private void FixedUpdate()
    {
        Attack();
    }   

    
}
