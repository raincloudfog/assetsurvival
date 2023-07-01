using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : Node
{
    public SequenceNode() : base() { }
    public SequenceNode(List<Node> children) : base(children) { }

    public override NodeState Evaluate()
    {
        bool bNOwRunning = false;
        foreach (Node node in children)
        {
            switch (node.Evaluate())
            {
                case NodeState.Running:
                    continue;
                case NodeState.failure:
                    return state = NodeState.failure; ;
                case NodeState.Success:
                    bNOwRunning = true;
                    continue;                
            }
        }
        return state = bNOwRunning ? NodeState.Running : NodeState.Success;
    }

    
}
