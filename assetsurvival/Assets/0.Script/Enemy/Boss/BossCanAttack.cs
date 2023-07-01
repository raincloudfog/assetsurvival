using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCanAttack : Node
{
    Rigidbody rigid;
    Animator anim;
    public BossCanAttack(Rigidbody rigid, Animator anim)
    {
        this.rigid = rigid;
        this.anim = anim;
    }

    public override NodeState Evaluate()
    {
        rigid.velocity = Vector3.zero;
        anim.SetBool("Walk", false);
        return NodeState.Running;
    }
}
