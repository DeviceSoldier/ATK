using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private Dictionary<T, StateMachineNode<T>> _nodes;
    private T _currentNodeId;

    public StateMachine()
    {
        _nodes = new Dictionary<T, StateMachineNode<T>>();
    }

    public void SetEntry(T nodeId)
    {
        if (!_nodes.ContainsKey(nodeId))
            return;
        
        _currentNodeId = nodeId;
        _nodes[nodeId].Enter();
    }

    public void AddNode(StateMachineNode<T> node)
    {
        var key = node.NodeId;
        if (_nodes.ContainsKey(key))
            _nodes[key] += node;
        else
            _nodes.Add(key, node);
    }

    public void AddNode(T nodeId, Action onUpdate, Action onEnter, Action onLeave)
    {
        StateMachineNode<T> node = new StateMachineNode<T>(nodeId);
        node.AddUpdateFunc(onUpdate);
        node.AddEnterFunc(onEnter);
        node.AddLeaveFunc(onLeave);
        AddNode(node);
    }

    public void AddEdge(T nodeId, StateMachineEdge<T> edge)
    {
        if (!_nodes.ContainsKey(nodeId))
            return;
        _nodes[nodeId].AddEdge(edge);
    }

    public void AddEdge(T from, T to, Func<bool> condition)
    {
        StateMachineEdge<T> edge = new StateMachineEdge<T>(to);
        edge.AddTransformConditionFunc(condition);
        AddEdge(from, edge);
    }

    private void SetState(T nodeId)
    {
        if (!_nodes.ContainsKey(nodeId))
            return;
        _nodes[_currentNodeId].Leave();
        _currentNodeId = nodeId;
        _nodes[nodeId].Enter();
    }

    public void Update()
    {
        if (!_nodes.ContainsKey(_currentNodeId))
            return;

        var transformed = false;
        var currentNode = _nodes[_currentNodeId];
        var edges = currentNode.Edges;
        foreach (var edge in edges.Values)
            if (edge.CanTransform)
            {
                SetState(edge.NextNodeId);
                transformed = true;
                break;
            }

        if (!transformed)
            currentNode.Update();
    }
}