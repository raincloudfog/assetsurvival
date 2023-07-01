using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorTree : MonoBehaviour
{
    private Node rootNode;

    protected virtual void Start()
    {
        rootNode = SetupBehaviorTree();
    }

    protected virtual void Update()
    {
        if (rootNode is null) return;
        rootNode.Evaluate();
    }

    protected abstract Node SetupBehaviorTree();
}
