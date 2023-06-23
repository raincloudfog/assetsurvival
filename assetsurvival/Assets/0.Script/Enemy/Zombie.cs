using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    

    public override void SetData(Attributes.Monster data, Player player)
    {
        this.data = data;
        this.Hp = data.Hp;
        this.maxHP = data.Hp;
        Damage = data.power;
        Agent.speed = data.movespeed;
        this.player = player;
        transform.localScale = new Vector3(1, 1, 1);
    }

    


}
