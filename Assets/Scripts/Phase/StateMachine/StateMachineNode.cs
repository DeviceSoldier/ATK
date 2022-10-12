using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachineNode<T>
{
    public T NodeId { get; private set; }
    internal Dictionary<T, StateMachineEdge<T>> Edges;
    internal Action OnEnterFunc { get; private set; } = () => { };
    internal Action OnLeaveFunc { get; private set; } = () => { };
    internal Action OnUpdateFunc { get; private set; } = () => { };

    public StateMachineNode(T nodeId)
    {
        Edges = new Dictionary<T, StateMachineEdge<T>>();
        NodeId = nodeId;
    }
    
    public void AddEnterFunc(Action func)
    {
        OnEnterFunc += func;
    }

    public void RemoveEnterFunc(Action func)
    {
        OnEnterFunc -= func;
    }

    public void AddLeaveFunc(Action func)
    {
        OnLeaveFunc += func;
    }

    public void RemoveLeaveFunc(Action func)
    {
        OnLeaveFunc -= func;
    }

    public void AddUpdateFunc(Action func)
    {
        OnUpdateFunc += func;
    }

    public void RemoveUpdateFunc(Action func)
    {
        OnUpdateFunc -= func;
    }
    
    internal void Enter()
    {
        OnEnterFunc.Invoke();
    }

    internal void Leave()
    {
        OnLeaveFunc.Invoke();
    }

    internal void Update()
    {
        OnUpdateFunc.Invoke();
    }
    
    public void AddEdge(StateMachineEdge<T> edge)
    {
        var key = edge.NextNodeId;
        if (Edges.ContainsKey(key))
        {
            Edges[key] += edge;
        }
        else
        {
            Edges.Add(key, edge);
        }
    }

    public void RemoveEdge(T targetId)
    {
        if (Edges.ContainsKey(targetId))
            Edges.Remove(targetId);
    }

    public StateMachineEdge<T> GetEdge(T targetId)
    {
        if (!Edges.ContainsKey(targetId))
            return null;
        return Edges[targetId];
    }
    
    public static StateMachineNode<T> operator+(StateMachineNode<T> a,StateMachineNode<T> b)
    {
        foreach (var keypair in b.Edges)
        {
            if(!a.Edges.ContainsKey(keypair.Key))
                continue;
            a.Edges[keypair.Key] += keypair.Value;
        }

        a.OnEnterFunc += b.OnEnterFunc;
        a.OnLeaveFunc += b.OnLeaveFunc;
        a.OnUpdateFunc += b.OnUpdateFunc;

        return a;
    }
}