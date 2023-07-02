using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMove : Node
{
    [SerializeField] NavMeshAgent Agent;
    Transform player;
    Animator anim;


    public BossMove(NavMeshAgent Agent, Transform player,Animator anim)
    {
        this.Agent = Agent;
        this.player = player;
        this.anim = anim;
    }

    public override NodeState Evaluate()
    {
        anim.SetBool("Walk", true);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Z_Idle") == true)
        {
        }
        else 
        {
            Agent.SetDestination(player.position);
        }
        

        return NodeState.Running;
    }


}
