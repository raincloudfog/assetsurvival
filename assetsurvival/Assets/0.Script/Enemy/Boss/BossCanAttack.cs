using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCanAttack : Node
{
    Collider[] colliders;
    Transform TF;
    Rigidbody rigid;
    Player player;
    Animator anim;
    public BossCanAttack(Transform TF,Rigidbody rigid, Animator anim, Player player)
    {
        this.TF = TF;
        this.rigid = rigid;
        this.anim = anim;
        this.player = player;
    }


    public override NodeState Evaluate()
    {
        colliders = Physics.OverlapSphere(TF.forward, 1, LayerMask.GetMask("Player"));
        rigid.velocity = Vector3.zero;
        anim.SetBool("Walk", false);
        anim.Play("Z_Attack");
        if (colliders.Length > 0)
        {            
            player.HIt(2);
        }

        
        return NodeState.Running;
    }
}
