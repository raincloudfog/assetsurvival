using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    

    public override void SetData(Attributes.Monster data, Player player)
    {
        this.data = data;
        this.maxHP = data.Hp;
        Agent.speed = data.movespeed;
        this.player = player;
    }

    
}
