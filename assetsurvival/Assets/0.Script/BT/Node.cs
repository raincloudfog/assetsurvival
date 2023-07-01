using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NodeState 
{
    Running,
    failure,
    Success
}

public abstract class Node 
{
    protected NodeState state;
    public Node parentNode;
    protected List<Node> children = new List<Node>();

    public Node()
    {
        parentNode = null;
    }

    public Node(List<Node> children)
    {
        foreach (var child in children)
        {
            AttatchChild(child);
        }
    }

    public void AttatchChild(Node child)
    {
        children.Add(child);
        child.parentNode = this;
    }

    public abstract NodeState Evaluate();
}
