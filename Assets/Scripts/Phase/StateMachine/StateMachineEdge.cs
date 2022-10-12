using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineEdge<T>
{
    internal T NextNodeId { get; private set; }

    internal Func<bool> CanTransformConditionFunc { get; private set; } = () => true;

    public StateMachineEdge(T targetId)
    {
        this.NextNodeId = targetId;
    }

    public void AddTransformConditionFunc(Func<bool> func)
    {
        CanTransformConditionFunc += func;
    }

    public void RemoveTransformConditionFunc(Func<bool> func)
    {
        CanTransformConditionFunc -= func;
    }

    internal bool CanTransform
    {
        get
        {
            var canTransform = true;
            var canTransformFuncList = CanTransformConditionFunc.GetInvocationList();
            foreach (var func in canTransformFuncList)
            {
                var flag = (bool)func.DynamicInvoke();
                canTransform &= flag;
                if (!flag)
                    break;
            }

            return canTransform;
        }
    }



    public static StateMachineEdge<T> operator +(StateMachineEdge<T> a,StateMachineEdge<T> b)
    {
        var key = b.NextNodeId;
        if (a.NextNodeId.Equals(key))
        {
            a.AddTransformConditionFunc(b.CanTransformConditionFunc);
        }
        return a;
    }
}