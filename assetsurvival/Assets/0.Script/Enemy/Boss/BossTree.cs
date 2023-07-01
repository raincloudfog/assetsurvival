using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossTree : BehaviorTree
{
    [SerializeField] NavMeshAgent Agent;
    [SerializeField] Rigidbody rigid;
    [SerializeField] Animator anim;
    [SerializeField] Player PlayerTf;

    public void Init()
    {
        PlayerTf = CharacterManager.Instance.MainPlayer;
    }
    protected override void Start()
    {
        
        base.Start();
    }

    protected override Node SetupBehaviorTree()
    {
        Node root = new SelectorNode(new List<Node>
        {
             new SequenceNode(new List<Node>{
                 new PlayerNear(transform),
                 new BossCanAttack(rigid, anim),
             }),
            new BossMove(Agent, PlayerTf.transform, anim)
        });

        return root;
    }
}
