using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : Node
{
    public SelectorNode() : base() { }
    public SelectorNode(List<Node> children) : base(children) { }

    public override NodeState Evaluate()
    {
        foreach (Node node in children)
        {
            switch (node.Evaluate())
            {
                case NodeState.Running:
                    return state = NodeState.Running;                    
                case NodeState.failure:
                    continue;
                case NodeState.Success:
                    return state = NodeState.Success;
            }
        }

        return state = NodeState.failure;
    }
}
