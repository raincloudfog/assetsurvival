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
        

        Agent.SetDestination(player.position);
        anim.SetBool("Walk", true);
        return NodeState.Running;
    }


}
