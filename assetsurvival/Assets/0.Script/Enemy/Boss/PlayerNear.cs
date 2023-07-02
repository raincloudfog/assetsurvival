using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNear : Node
{
    Collider[] colliders;
    Transform TF;

    public PlayerNear(Transform TF)
    {
        this.TF = TF;
    }

    public override NodeState Evaluate()
    {
        colliders = Physics.OverlapSphere(TF.position, 1,LayerMask.GetMask("Player"));

        if(colliders.Length > 0)
        {
            return NodeState.Success;
        }
        return NodeState.failure;
    }
}
